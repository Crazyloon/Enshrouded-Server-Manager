using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services;

public class EnshroudedServerService : IEnshroudedServerService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IEventAggregator _eventAggregator;

    private const string SERVER_PROCESS_NAME = "enshrouded_server";

    public EnshroudedServerService(IFileSystemService fsm,
        IEventAggregator eventAggregator)
    {
        _fileSystemService = fsm;
        _eventAggregator = eventAggregator;
    }

    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

    delegate Boolean ConsoleCtrlDelegate(CtrlTypes type);

    enum CtrlTypes : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

    /// <summary>
    /// Start Gameserver
    /// </summary>
    public void Start(string pathServerExe, string selectedProfileName)
    {

        try
        {
            Process p = Process.Start(pathServerExe);
            //Thread.Sleep(10000);
            //SetWindowText(p.MainWindowHandle, ServerName);
            int pid = p.Id;

            var serverCachePath = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName);

            _fileSystemService.CreateDirectory(serverCachePath);
            EnshroudedServerProcess json = new EnshroudedServerProcess()
            {
                Id = pid,
                Profile = selectedProfileName
            };

            var output = JsonConvert.SerializeObject(json);
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
            _fileSystemService.WriteFile(pidJsonFile, output);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_START_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_START_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }
    }

    public CountDownTimer? StartScheduledRestarts(ServerProfile serverProfile)
    {
        // get the server profile auto restart settings
        var autoRestart = serverProfile.ScheduleRestarts;
        if (autoRestart is null || !autoRestart.Enabled)
        {
            return null;
        }

        // calculate TimeSpan from now until the start date and time
        var now = DateTime.Now;
        var startDate = new DateTime(autoRestart.StartDate.Year, autoRestart.StartDate.Month, autoRestart.StartDate.Day, autoRestart.StartTime.Hour, autoRestart.StartTime.Minute, 0);

        if (startDate < now || serverProfile.ScheduleRestarts.RestartFrequency == RestartFrequency.None)
        {
            return null;
        }

        var nextRestart = startDate - now;

        // start a countdown timer for the next restart
        var timer = new CountDownTimer(nextRestart);
        timer.CountDownFinished += OnCountDownFinished(serverProfile, timer);
        timer.TimeChanged += () => _eventAggregator.Publish(new ServerResetTimerUpdatedMessage(serverProfile, timer.TimeLeftStr));

        timer.Start();

        return timer;
    }

    private Action OnCountDownFinished(ServerProfile profile, CountDownTimer timer)
    {
        return () =>
        {
            var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profile.Name);
            _fileSystemService.CreateDirectory(serverProfilePath);
            var gameServerExe = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_EXE);

            // Only restart the server if it's the right day of the week
            if (profile.ScheduleRestarts.DaysOfWeek.Length > 0
            && !profile.ScheduleRestarts.DaysOfWeek.Contains(DateTime.Now.DayOfWeek))
            {
                return;
            }

            Stop(profile.Name);

            if (profile.RestoreBackup.RestoreOnScheduledRestart)
            {
                RestoreBackup(profile.Name, profile.RestoreBackup.BackupFilePath);
            }

            Start(gameServerExe, profile.Name);

            // check the restart settings to see if it should begin the timer again
            var nextRestart = CalculateNextRestart(profile.ScheduleRestarts);
            var nextTimeSpan = nextRestart - DateTime.Now;

            // if the nextTimeSpan is in the past, stop the timer and dispose
            if (nextTimeSpan.TotalMilliseconds <= 0)
            {
                timer.EndTimer();
                return;
            }

            // End existing timer and start a new one
            timer.EndTimer();

            timer = new CountDownTimer(nextTimeSpan);
            timer.CountDownFinished += OnCountDownFinished(profile, timer);
            timer.TimeChanged += () => _eventAggregator.Publish(new ServerResetTimerUpdatedMessage(profile, timer.TimeLeftStr));

            timer.Start();
        };
    }

    private DateTime CalculateNextRestart(ScheduleRestarts autoRestart)
    {
        var now = DateTime.Now;
        var nextRestart = now;

        switch (autoRestart.RestartFrequency)
        {
            case RestartFrequency.Hourly:
                //nextRestart = now.AddSeconds(autoRestart.RecurrenceInterval);
                nextRestart = now.AddHours(autoRestart.RecurrenceInterval);
                break;
            case RestartFrequency.Daily:
                nextRestart = now.AddDays(autoRestart.RecurrenceInterval);
                break;
            case RestartFrequency.Weekly:
                nextRestart = now.AddDays(7 * autoRestart.RecurrenceInterval);
                break;
            case RestartFrequency.Monthly:
                nextRestart = now.AddMonths(autoRestart.RecurrenceInterval);
                break;
            default:
                break;
        }

        return nextRestart;
    }

    private bool RestoreBackup(string profileName, string backupFilePath)
    {
        var saveDirectory = Path.Combine(Constants.Paths.SERVER_DIRECTORY, profileName, Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY);

        if (backupFilePath.EndsWith(".zip"))
        {
            return RestoreBackupFromZip(backupFilePath, saveDirectory);
        }

        return RestoreBackupFromSaveFile(backupFilePath, saveDirectory);
    }

    private bool RestoreBackupFromSaveFile(string backupFilePath, string saveDirectory)
    {
        try
        {
            var saveFile = Path.Combine(saveDirectory, Constants.SaveSlots.SLOT1);
            _fileSystemService.CopyFile(backupFilePath, saveFile, true);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool RestoreBackupFromZip(string backupFilePath, string saveDirectory)
    {
        try
        {
            // extract the zipped files to a temp directory
            var tempDir = Path.Combine(saveDirectory, "temp");
            _fileSystemService.ExtractZipToDirectory(backupFilePath, tempDir, true);

            // copy the save file in the temp directory to the savegame directory
            var tempFile = Path.Combine(tempDir, Constants.SaveSlots.SLOT1);
            var saveFile = Path.Combine(saveDirectory, Constants.SaveSlots.SLOT1);
            _fileSystemService.CopyFile(tempFile, saveFile, true);

            // delete temp
            _fileSystemService.DeleteDirectory(tempDir);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Install/Validate/Update GameServer Files
    /// </summary>
    public void InstallUpdate(string steamAppId, string serverProfilePath, string selectedProfileName)
    {
        try
        {
            Process p = Process.Start(Constants.ProcessNames.STEAM_CMD_EXE, $"+force_install_dir \"{serverProfilePath}\" +login anonymous +app_update {steamAppId} validate +quit");
            p.WaitForExit();
        }

        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_UPDATE_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_UPDATE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Stop Gameserver
    /// </summary>
    public void Stop(string selectedProfileName)
    {
        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
        if (!_fileSystemService.FileExists(pidJsonFile))
        {
            return;
        }

        // Load pid
        var input = _fileSystemService.ReadFile(pidJsonFile);

        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        int pid = serverProcessInfo.Id;
        string name = serverProcessInfo.Profile;

        try
        {
            Process p = Process.GetProcessById(pid);
            FreeConsole();
            if (AttachConsole((uint)pid))
            {
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
                Thread.Sleep(2000);
                FreeConsole();
                SetConsoleCtrlHandler(null, false);
            }
        }
        catch (ArgumentException)
        {
            return;
        }

        _fileSystemService.DeleteFile(pidJsonFile);
    }

    public bool IsRunning(string selectedProfileName)
    {
        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);
        if (!_fileSystemService.FileExists(pidJsonFile))
        {
            return false;
        }

        var input = _fileSystemService.ReadFile(pidJsonFile);
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        if (serverProcessInfo == null)
        {
            return false;
        }

        Process p;
        try
        {
            p = Process.GetProcessById(serverProcessInfo.Id);
        }
        catch (ArgumentException)
        {
            // The process doesn't exist anymore, so we can delete the pid file
            if (_fileSystemService.FileExists(pidJsonFile))
            {
                _fileSystemService.DeleteFile(pidJsonFile);
            }

            return false;
        }

        return SERVER_PROCESS_NAME == p.ProcessName;
    }
}
