using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;
public class ScheduledRestartService : IScheduledRestartService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IFileLoggerService _logger;
    private readonly IBackupService _backupService;
    private readonly IEnshroudedServerService _serverService;
    private readonly IEventAggregator _eventAggregator;
    private readonly IDiscordService _discordService;

    Dictionary<string, CountDownTimer> _restartTimers;

    public ScheduledRestartService(IFileSystemService fileSystemService,
        IFileLoggerService logger,
        IBackupService backupService,
        IEnshroudedServerService enshroudedServerService,
        IEventAggregator eventAggregator,
        IDiscordService discordService,
        Dictionary<string, CountDownTimer> restartTimers)
    {
        _fileSystemService = fileSystemService;
        _logger = logger;
        _backupService = backupService;
        _serverService = enshroudedServerService;
        _eventAggregator = eventAggregator;
        _discordService = discordService;
        _restartTimers = restartTimers;
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
        DateTime startDate;
        if (autoRestart.StartScheduleWithServer)
        {
            startDate = CalculateNextRestart(autoRestart);
        }
        else
        {
            startDate = new DateTime(autoRestart.StartDate.Year, autoRestart.StartDate.Month, autoRestart.StartDate.Day,
                autoRestart.StartTime.Hour, autoRestart.StartTime.Minute, autoRestart.StartTime.Second);
        }


        if (startDate < now || serverProfile.ScheduleRestarts.RestartFrequency == RestartFrequency.None)
        {
            return null;
        }

        var nextRestart = startDate - now;

        // Make sure no timer for this server already exists
        if (_restartTimers.ContainsKey(serverProfile.Name))
        {
            var dicTimer = _restartTimers[serverProfile.Name];
            dicTimer.EndTimer();
            dicTimer = null;
            _restartTimers.Remove(serverProfile.Name);
        }

        // start a countdown timer for the next restart
        var timer = new CountDownTimer(nextRestart);
        timer.CountDownFinished += OnCountDownFinished(serverProfile, timer);
        timer.TimeChanged += () => _eventAggregator.Publish(new ServerResetTimerUpdatedMessage(serverProfile, timer.TimeLeftStr));

        timer.Tag = "TimerTag: Initial";
        timer.Start();

        _restartTimers.Add(serverProfile.Name, timer);
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


            _serverService.Stop(profile);
            _discordService.SendMessage(profile, DiscordMessageType.ServerStopped);

            if (profile.RestoreBackup.RestoreOnScheduledRestart)
            {
                _backupService.RestoreBackup(profile, profile.RestoreBackup.BackupFilePath);
            }

            _serverService.Start(gameServerExe, profile);
            _discordService.SendMessage(profile, DiscordMessageType.ServerStarted);

            // check the restart settings to see if it should begin the timer again
            var nextRestart = CalculateNextRestart(profile.ScheduleRestarts);
            var nextTimeSpan = nextRestart - DateTime.Now;

            // if the nextTimeSpan is in the past, stop the timer and dispose
            if (nextTimeSpan.TotalMilliseconds <= 0)
            {
                _logger.LogInfo("CountDownTimer: OnCountDownFinished: nextTimeSpan is in the past. Timer will not be restarted.");
                timer.EndTimer();
                return;
            }

            // End existing timer and start a new one
            _restartTimers.Remove(profile.Name);
            timer.EndTimer();
            timer = null;

            timer = new CountDownTimer(nextTimeSpan);
            timer.CountDownFinished += OnCountDownFinished(profile, timer);
            timer.TimeChanged += () => _eventAggregator.Publish(new ServerResetTimerUpdatedMessage(profile, timer.TimeLeftStr));
            timer.Tag = $"{DateTime.Now.ToString("dd/MM/yyyyThh:mm:ss")}-CountDownFinished";

            _logger.LogInfo($"TimerTag: {timer.Tag}");

            _restartTimers.Add(profile.Name, timer);
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
}
