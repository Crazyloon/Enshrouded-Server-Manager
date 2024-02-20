namespace Enshrouded_Server_Manager.Views;
public partial class NavBarView : UserControl, INavBarView
{
    public NavBarView()
    {
        InitializeComponent();
    }
    public event EventHandler HomeClicked
    {
        add => btnHome.Click += value;
        remove => btnHome.Click -= value;
    }

    public event EventHandler ProfileSettingsClicked
    {
        add => btnProfileSettings.Click += value;
        remove => btnProfileSettings.Click -= value;
    }

    public event EventHandler ServerSettingsClicked
    {
        add => btnServerSettings.Click += value;
        remove => btnServerSettings.Click -= value;
    }

    public event EventHandler AutoBackupClicked
    {
        add => btnAutoBackup.Click += value;
        remove => btnAutoBackup.Click -= value;
    }

    public event EventHandler RestoreBackupClicked
    {
        add => btnRestoreBackup.Click += value;
        remove => btnRestoreBackup.Click -= value;
    }

    public event EventHandler ScheduleRestartsClicked
    {
        add => btnScheduleRestarts.Click += value;
        remove => btnScheduleRestarts.Click -= value;
    }

    public event EventHandler DiscordNotificationsClicked
    {
        add => btnDiscordNotifications.Click += value;
        remove => btnDiscordNotifications.Click -= value;
    }

    public string CurrentVersionText
    {
        get => lblVersion.Text;
        set => lblVersion.Text = value;
    }
}
