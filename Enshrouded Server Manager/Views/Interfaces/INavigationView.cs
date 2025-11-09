using Enshrouded_Server_Manager.Enums;

namespace Enshrouded_Server_Manager.Views;

public interface INavigationView
{
    event EventHandler HomeClicked;
    event EventHandler ServerSettingsClicked;
    event EventHandler GameSettingsClicked;
    event EventHandler UserGroupSettingsClicked;
    event EventHandler AutoBackupClicked;
    event EventHandler RestoreBackupClicked;
    event EventHandler ScheduleRestartsClicked;
    event EventHandler DiscordNotificationsClicked;
    event EventHandler CreditsClicked;

    string CurrentVersionText { get; set; }
    bool IsNewVersionAvailable { get; set; }
    ViewSelection SelectedView { get; set; }
}