using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ScheduleRestartsPresenter
{
    private readonly IScheduleRestartsView _view;
    private readonly IEventAggregator _eventAggregator;
    private readonly IEnshroudedServerService _server;
    private readonly IBackupService _backupService;
    private readonly IMessageBoxService _messageBox;
    private readonly IFileSystemService _fileSystemService;
    private readonly IFileLoggerService _logger;
    private readonly IScheduledRestartService _scheduledRestartService;

    Dictionary<string, CountDownTimer> _restartTimers;
    private ServerProfile _selectedProfile;
    private BindingList<ServerProfile>? _profiles;


    public ScheduleRestartsPresenter(IScheduleRestartsView scheduleRestartsView,
        IEventAggregator eventAggregator,
        IEnshroudedServerService server,
        IBackupService backupService,
        IMessageBoxService messageBox,
        IFileSystemService fileSystemService,
        IFileLoggerService fileLogger,
        IScheduledRestartService scheduledRestartService,
        Dictionary<string, CountDownTimer> restartTimers,
        BindingList<ServerProfile>? profiles)
    {
        _view = scheduleRestartsView;
        _eventAggregator = eventAggregator;
        _server = server;
        _backupService = backupService;
        _messageBox = messageBox;
        _fileSystemService = fileSystemService;
        _logger = fileLogger;
        _scheduledRestartService = scheduledRestartService;
        _restartTimers = restartTimers;
        _profiles = profiles;

        _view.SaveSettings += (sender, e) => OnSaveSettingsClicked();
        _view.ClearAll += (sender, e) => OnClearAllClicked();
        _view.RestartFrequencyChanged += (sender, e) => OnRestartFrequencyChanged();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerResetTimerUpdatedMessage>(p => OnServerResetTimerUpdated(p.ServerProfile, p.TimeLeft));
    }

    private void OnServerResetTimerUpdated(ServerProfile serverProfile, string timeLeft)
    {
        if (serverProfile == _selectedProfile)
        {
            _view.TimeLeft = $"Next Restart: {timeLeft}";
        }
    }

    private void OnRestartFrequencyChanged()
    {
        switch (_view.RestartFrequency)
        {
            case RestartFrequency.None:
                _view.ToggleDaysOfWeek(false);
                _view.ToggleStartWithServer(false);
                _view.ToggleRecurrenceInterval(false);
                break;
            case RestartFrequency.OneTime:
                _view.ToggleDaysOfWeek(false);
                _view.ToggleStartWithServer(false);
                _view.ToggleRecurrenceInterval(false);
                break;
            case RestartFrequency.Hourly:
                _view.RecurrenceIntervalUnit = "Hour(s)";
                _view.ToggleDaysOfWeek(false);
                _view.ToggleStartWithServer(true);
                _view.ToggleRecurrenceInterval(true);
                break;
            case RestartFrequency.Daily:
                _view.RecurrenceIntervalUnit = "Day(s)";
                _view.ToggleDaysOfWeek(false);
                _view.ToggleStartWithServer(true);
                _view.ToggleRecurrenceInterval(true);
                break;
            case RestartFrequency.Weekly:
                _view.RecurrenceIntervalUnit = "Week(s)";
                _view.ToggleDaysOfWeek(true);
                _view.ToggleStartWithServer(true);
                _view.ToggleRecurrenceInterval(true);
                break;
            case RestartFrequency.Monthly:
                _view.RecurrenceIntervalUnit = "Month(s)";
                _view.ToggleDaysOfWeek(false);
                _view.ToggleStartWithServer(true);
                _view.ToggleRecurrenceInterval(true);
                break;

            default:
                break;
        }
    }

    private void OnClearAllClicked()
    {
        _view.RestartFrequency = RestartFrequency.None;
        _view.StartDate = DateOnly.FromDateTime(DateTime.Now);
        _view.StartTime = TimeOnly.FromDateTime(DateTime.Now);
        _view.DaysOfWeek = new DayOfWeek[] { };
        _view.RecurrenceInterval = 1;
        _view.IsScheduledRestartEnabled = false;
        _view.IsScheduledWithServerStart = false;
    }

    private void OnSaveSettingsClicked()
    {
        // Ensure valid settings
        if (_view.IsScheduledRestartEnabled && !_view.IsScheduledWithServerStart)
        {
            var startDateTime = new DateTime(_view.StartDate.Year, _view.StartDate.Month, _view.StartDate.Day,
                               _view.StartTime.Hour, _view.StartTime.Minute, _view.StartTime.Second);

            if (startDateTime < DateTime.Now)
            {
                _messageBox.Show(Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR_MESSAGE, Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Apply the settings to the profile
        if (_selectedProfile.ScheduleRestarts is null)
        {
            _selectedProfile.ScheduleRestarts = new ScheduleRestarts()
            {
                RestartFrequency = RestartFrequency.None,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                StartTime = TimeOnly.FromDateTime(DateTime.Now),
                DaysOfWeek = new DayOfWeek[] { },
                RecurrenceInterval = 0,
                Enabled = false,
                StartScheduleWithServer = false
            };
        }

        _selectedProfile.ScheduleRestarts.RestartFrequency = _view.RestartFrequency;
        _selectedProfile.ScheduleRestarts.StartDate = _view.StartDate;
        _selectedProfile.ScheduleRestarts.StartTime = _view.StartTime;
        _selectedProfile.ScheduleRestarts.DaysOfWeek = _view.DaysOfWeek;
        _selectedProfile.ScheduleRestarts.RecurrenceInterval = _view.RecurrenceInterval;
        _selectedProfile.ScheduleRestarts.Enabled = _view.IsScheduledRestartEnabled;
        _selectedProfile.ScheduleRestarts.StartScheduleWithServer = _view.IsScheduledWithServerStart;

        // write the updated profile to the json file
        _fileSystemService.WriteFile(Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
                JsonConvert.SerializeObject(_profiles, JsonSettings.Default));

        if (_server.IsRunning(_selectedProfile.Name))
        {
            _scheduledRestartService.StartScheduledRestarts(_selectedProfile);
        }

        _view.AnimateSaveButton();
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;

        if (_selectedProfile.ScheduleRestarts is null)
        {
            _selectedProfile.ScheduleRestarts = new ScheduleRestarts()
            {
                RestartFrequency = RestartFrequency.None,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                StartTime = TimeOnly.FromDateTime(DateTime.Now),
                DaysOfWeek = new DayOfWeek[] { },
                RecurrenceInterval = 0,
                Enabled = false
            };
        }

        // load the settings for this profile
        _view.RestartFrequency = _selectedProfile.ScheduleRestarts.RestartFrequency;
        _view.StartDate = _selectedProfile.ScheduleRestarts.StartDate;
        _view.StartTime = _selectedProfile.ScheduleRestarts.StartTime;
        _view.DaysOfWeek = _selectedProfile.ScheduleRestarts.DaysOfWeek;
        _view.RecurrenceInterval = _selectedProfile.ScheduleRestarts.RecurrenceInterval;
        _view.IsScheduledRestartEnabled = _selectedProfile.ScheduleRestarts.Enabled;
        _view.IsScheduledWithServerStart = _selectedProfile.ScheduleRestarts.StartScheduleWithServer;

        // update the timer if necessary
        if (_restartTimers.ContainsKey(_selectedProfile.Name))
        {
            _view.TimeLeft = $"Next Restart: {_restartTimers[_selectedProfile.Name].TimeLeftStr}";
        }
        else
        {
            _view.TimeLeft = "Next Restart: N/A";
        }
    }
}
