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
    private readonly IFileLoggerService _logger;

    private const string SERVER_PROCESS_NAME = "enshrouded_server";

    public EnshroudedServerService(IFileSystemService fsm,
        IEventAggregator eventAggregator,
        IFileLoggerService logger)
    {
        _fileSystemService = fsm;
        _eventAggregator = eventAggregator;
        _logger = logger;
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
    public async Task Start(string pathServerExe, ServerProfile profile)
    {

        try
        {
            // load appconfig.json
            var configText = _fileSystemService.ReadFile("./config.json");
            var config = JsonConvert.DeserializeObject<AppConfig>(configText);

            // Auto Update the server on startup if configured
            if (config.AutoUpdateServer.HasValue && config.AutoUpdateServer.Value == true)
            {
                if (await ServerUpdateCheck(profile.Name) == Color.Yellow)
                {
                    Update();
                }
            }

            ProcessStartInfo pi = new ProcessStartInfo(pathServerExe);
            if (config.StartServerMinimized.HasValue && config.StartServerMinimized.Value == true)
            {
                pi.UseShellExecute = true;
                pi.WindowStyle = ProcessWindowStyle.Minimized;
            }
            Process p = Process.Start(pi);

            _eventAggregator.Publish(new ServerStartedMessage(profile));
            //Thread.Sleep(10000);
            //SetWindowText(p.MainWindowHandle, ServerName);
            int pid = p.Id;

            var serverCachePath = Path.Join(Constants.Paths.CACHE_DIRECTORY, profile.Name);

            _fileSystemService.CreateDirectory(serverCachePath);
            EnshroudedServerProcess json = new EnshroudedServerProcess()
            {
                Id = pid,
                Profile = profile.Name
            };

            var output = JsonConvert.SerializeObject(json);
            var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, profile.Name, Constants.Files.PID_JSON);
            _fileSystemService.WriteFile(pidJsonFile, output);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_START_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_START_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }
    }

    /// <summary>
    /// Validate/Update GameServer Files
    /// </summary>
    public void Install(string serverProfilePath)
    {
        try
        {
            Process p = Process.Start(Constants.ProcessNames.STEAM_CMD_EXE, $"+force_install_dir \"{serverProfilePath}\" +login anonymous +app_update {Constants.STEAM_APP_ID} validate +quit");
            p.WaitForExit();
        }

        catch (Exception ex)
        {
            MessageBox.Show(string.Format(Constants.Errors.SERVER_UPDATE_ERROR_MESSAGE, ex.Message),
                Constants.Errors.SERVER_UPDATE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    // <summary>
    /// Validate/Install GameServer Files
    /// </summary>
    public void Update()
    {
        try
        {
            Process p = Process.Start(Constants.ProcessNames.STEAM_CMD_EXE, $"+login anonymous +app_update {Constants.STEAM_APP_ID} +quit");
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
    public void Stop(ServerProfile profile)
    {
        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, profile.Name, Constants.Files.PID_JSON);
        if (!_fileSystemService.FileExists(pidJsonFile))
        {
            _eventAggregator.Publish(new ServerStoppedMessage(profile));
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
            var timeout = 30000;
            var sleepTick = 200;

            if (AttachConsole((uint)pid))
            {
                SetConsoleCtrlHandler(null, true);
                if (!GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0))
                    return;
            }

            while (!p.HasExited) // process is still running so wait 30 more seconds then kill if it's still stuck
            {
                Thread.Sleep(sleepTick);
                timeout = timeout - sleepTick;

                if (timeout <= 0)
                {
                    p.Kill();
                    _logger.LogError($"Server Stop Failed for server {profile.Name}. Killing Process. Some progress may be lost.");
                    break;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"Server Stop Failed for server {profile.Name}. Error: {e.Message}");
            return;
        }
        finally
        {
            SetConsoleCtrlHandler(null, false);
            FreeConsole();

            _eventAggregator.Publish(new ServerStoppedMessage(profile));
            _fileSystemService.DeleteFile(pidJsonFile);
        }

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

    public async Task<Color> ServerUpdateCheck(string selectedProfileName)
    {
        using (HttpClient Client = new HttpClient())
        {
            try
            {
                // TODO Refactor this into the HTTPClientService so the tests don't 
                // have to send a real request to the server

                // check file for actual version
                HttpResponseMessage response = await Client.GetAsync(Constants.Urls.STEAM_CMD_ENSHROUDED_SERVER_INFO);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);

                // readout branches>public>buildid of actual version
                dynamic dataData = data["data"];
                dynamic steamidData = dataData[$"{Constants.STEAM_APP_ID}"];
                dynamic depotData = steamidData["depots"];
                dynamic branchesData = depotData["branches"];
                dynamic publicData = branchesData["public"];
                string buildId = publicData["buildid"];

                // readout servers/selectedprofilename/steamapps/appmanifest_$AppID.acf
                var steamappsPath = Path.Join(Constants.Paths.SERVER_DIRECTORY, selectedProfileName, Constants.Paths.GAME_SERVER_STEAMAPPS_DIRECTORY);
                var file = Path.Join(steamappsPath, Constants.Files.APP_MANIFEST);

                // check if file contains buildId
                if (!AppManifestContainsBuildId(file, buildId))
                {
                    return Color.Yellow;
                }
                else
                {
                    return Color.Green;
                }
            }
            catch (Exception)
            {
                return Color.Red;
            }
        }
    }

    private bool AppManifestContainsBuildId(string manifestFile, string buildId)
    {
        string manifestBuildId = string.Empty;
        var lines = _fileSystemService.ReadLines(manifestFile);
        var buildIdLine = lines.FirstOrDefault(line => line.Contains("buildid"));
        manifestBuildId = buildIdLine.Split("\t").Last().Replace("\"", string.Empty);

        return buildId == manifestBuildId;
    }
}
