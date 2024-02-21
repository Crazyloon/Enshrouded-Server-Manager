using Enshrouded_Server_Manager.Enums;

namespace Enshrouded_Server_Manager.Views;
public partial class NavigationView : UserControl, INavigationView
{
    public NavigationView()
    {
        InitializeComponent();
    }
    public event EventHandler HomeClicked
    {
        add => btnHome.Click += value;
        remove => btnHome.Click -= value;
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

    public event EventHandler CreditsClicked
    {
        add => btnCredits.Click += value;
        remove => btnCredits.Click -= value;
    }

    public string CurrentVersionText
    {
        get => lblVersion.Text;
        set => lblVersion.Text = value;
    }

    public bool IsNewVersionAvailable
    {
        get => lblNewVersion.Visible;
        set => lblNewVersion.Visible = value;
    }

    public ViewSelection SelectedView { get; set; }
}
