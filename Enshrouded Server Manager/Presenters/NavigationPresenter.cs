using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class NavigationPresenter
{
    private readonly INavigationView _view;
    private readonly IVersionManagementService _versionManagementService;
    private readonly IEventAggregator _eventAggregator;

    public NavigationPresenter(INavigationView view,
        IVersionManagementService versionManagement,
        IEventAggregator eventAggregator)
    {
        _view = view;
        _versionManagementService = versionManagement;
        _eventAggregator = eventAggregator;

        _view.HomeClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.Home);
        _view.ServerSettingsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.ServerSettings);
        _view.GameSettingsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.GameSettings);
        _view.UserGroupSettingsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.UserGroupSettings);
        _view.AutoBackupClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.AutoBackup);
        _view.RestoreBackupClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.RestoreBackup);
        _view.ScheduleRestartsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.ScheduleRestarts);
        _view.DiscordNotificationsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.DiscordNotifications);
        _view.CreditsClicked += (sender, e) => OnViewSelectionChanged(ViewSelection.Credits);

        _eventAggregator.Subscribe<NewVersionAvailableMessage>(n => OnNewVersionAvailable());

        BeginApplicationVersionCheckTimer();
    }

    private void OnNewVersionAvailable()
    {
        _view.IsNewVersionAvailable = true;
    }

    private void BeginApplicationVersionCheckTimer()
    {
        _view.CurrentVersionText = _versionManagementService.SyncVersionText();
        _versionManagementService.ManagerUpdate(_view.CurrentVersionText);
    }

    private void OnViewSelectionChanged(ViewSelection viewSelection)
    {
        _view.SelectedView = viewSelection;

        _eventAggregator.Publish(new NavigationChangedMessage(viewSelection));
    }
}
