namespace Enshrouded_Server_Manager.Views;

internal interface INavBarView
{
    event EventHandler HomeClicked;
    event EventHandler ServerSettingsClicked;
    event EventHandler AutoBackupClicked;
    event EventHandler RestoreBackupClicked;
    event EventHandler ScheduleRestartsClicked;
    event EventHandler DiscordNotificationsClicked;

    string CurrentVersionText { get; set; }
}