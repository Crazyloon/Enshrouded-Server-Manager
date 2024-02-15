using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class ScheduleRestartsPresenter
{
    private readonly IScheduleRestartsView _view;
    private readonly IEventAggregator _eventAggregator;
    private readonly IEnshroudedServerService _server;
    private readonly IBackupService _backupService;
    private readonly IMessageBoxService _messageBox;

    private ServerProfile _selectedProfile;


    public ScheduleRestartsPresenter(IScheduleRestartsView scheduleRestartsView,
        IEventAggregator eventAggregator,
        IEnshroudedServerService server,
        IBackupService backupService,
        IMessageBoxService messageBox)
    {
        _view = scheduleRestartsView;
        _eventAggregator = eventAggregator;
        _server = server;
        _backupService = backupService;
        _messageBox = messageBox;

        _view.SaveSettings += (sender, e) => OnSaveSettingsClicked();
        _view.ClearAll += (sender, e) => OnClearAllClicked();
        _view.RestartFrequencyChanged += (sender, e) => OnRestartFrequencyChanged();
        _view.StartDateChanged += (sender, e) => OnStartDateChanged();
        _view.StartTimeChanged += (sender, e) => OnStartTimeChanged();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));

        _view.RestartFrequency = RestartFrequency.None;
        _view.StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        _view.StartTime = TimeOnly.FromDateTime(DateTime.Now.AddMinutes(10));
        _view.DaysOfWeek = new DayOfWeek[] { };
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

    private void OnStartDateChanged()
    {
        if (_view.StartDate < DateOnly.FromDateTime(DateTime.Now))
        {
            _messageBox.Show(Constants.Errors.SCHEDULED_RESTARTS_STARTDATE_ERROR_MESSAGE, Constants.Errors.SCHEDULED_RESTARTS_STARTDATE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _view.StartDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }

    private void OnStartTimeChanged()
    {
        if (_view.StartTime < TimeOnly.FromDateTime(DateTime.Now))
        {
            _messageBox.Show(Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR_MESSAGE, Constants.Errors.SCHEDULED_RESTARTS_STARTTIME_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _view.StartTime = TimeOnly.FromDateTime(DateTime.Now);
        }
    }

    private void OnClearAllClicked()
    {
        _view.RestartFrequency = RestartFrequency.None;
    }

    private void OnSaveSettingsClicked()
    {
        throw new NotImplementedException();
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        _selectedProfile = selectedProfile;
    }
}
