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

    private ServerProfile _selectedProfile;
    private BindingList<ServerProfile>? _profiles;


    public ScheduleRestartsPresenter(IScheduleRestartsView scheduleRestartsView,
        IEventAggregator eventAggregator,
        IEnshroudedServerService server,
        IBackupService backupService,
        IMessageBoxService messageBox,
        IFileSystemService fileSystemService,
        BindingList<ServerProfile>? profiles)
    {
        _view = scheduleRestartsView;
        _eventAggregator = eventAggregator;
        _server = server;
        _backupService = backupService;
        _messageBox = messageBox;
        _fileSystemService = fileSystemService;
        _profiles = profiles;

        _view.SaveSettings += (sender, e) => OnSaveSettingsClicked();
        _view.ClearAll += (sender, e) => OnClearAllClicked();
        _view.RestartFrequencyChanged += (sender, e) => OnRestartFrequencyChanged();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerResetTimerUpdatedMessage>(p => OnServerResetTimerUpdated(p.ServerProfile, p.TimeLeft));
    }

    private void OnServerResetTimerUpdated(ServerProfile serverProfile, string timeLeft)
    {
        _view.TimeLeft = "Next Restart: N/A";
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
            case RestartFrequency.OneTime:
                break;
            case RestartFrequency.Hourly:
                _view.RecurrenceIntervalUnit = "Hour(s)";
                break;
            case RestartFrequency.Daily:
                _view.RecurrenceIntervalUnit = "Day(s)";
                break;
            case RestartFrequency.Weekly:
                _view.RecurrenceIntervalUnit = "Week(s)";
                break;
            case RestartFrequency.Monthly:
                _view.RecurrenceIntervalUnit = "Month(s)";
                break;

            default:
                _view.RecurrenceIntervalUnit = "Minute(s)";
                break;
        }
    }

    private void OnClearAllClicked()
    {
        _view.RestartFrequency = RestartFrequency.None;
        _view.StartDate = DateOnly.FromDateTime(DateTime.Now);
        _view.StartTime = TimeOnly.FromDateTime(DateTime.Now);
        _view.DaysOfWeek = new DayOfWeek[] { };
        _view.RecurrenceInterval = 0;
        _view.IsScheduledRestartEnabled = false;
    }

    private void OnSaveSettingsClicked()
    {
        // Ensure valid settings
        if (_view.StartDate < DateOnly.FromDateTime(DateTime.Now))
        {
            _messageBox.Show(Constants.Errors.SCHEDULED_RESTARTS_STARTDATE_ERROR_MESSAGE, Constants.Errors.SCHEDULED_RESTARTS_STARTDATE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _view.StartDate = DateOnly.FromDateTime(DateTime.Now);

            return;
        }

        if (_view.StartTime < TimeOnly.FromDateTime(DateTime.Now))
        {
            _messageBox.Show(Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR_MESSAGE, Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _view.StartTime = TimeOnly.FromDateTime(DateTime.Now);

            return;
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
                Enabled = false
            };
        }

        _selectedProfile.ScheduleRestarts.RestartFrequency = _view.RestartFrequency;
        _selectedProfile.ScheduleRestarts.StartDate = _view.StartDate;
        _selectedProfile.ScheduleRestarts.StartTime = _view.StartTime;
        _selectedProfile.ScheduleRestarts.DaysOfWeek = _view.DaysOfWeek;
        _selectedProfile.ScheduleRestarts.RecurrenceInterval = _view.RecurrenceInterval;
        _selectedProfile.ScheduleRestarts.Enabled = _view.IsScheduledRestartEnabled;

        // write the updated profile to the json file
        _fileSystemService.WriteFile(
                Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.SERVER_PROFILES_JSON),
                JsonConvert.SerializeObject(_profiles, JsonSettings.Default));

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
    }
}
