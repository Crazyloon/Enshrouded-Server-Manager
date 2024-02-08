namespace Enshrouded_Server_Manager;
public partial class ServerSettingsView : UserControl, IServerSettingsView
{
    public ServerSettingsView()
    {
        InitializeComponent();
    }

    public string ServerName
    {
        get => txtServerName.Text;
        set => txtServerName.Text = value;
    }

    public string Password
    {
        get => txtServerPassword.Text;
        set => txtServerPassword.Text = value;
    }

    public string IpAddress
    {
        get => txtIpAddress.Text;
        set => txtIpAddress.Text = value;
    }

    public int GamePort
    {
        get => (int)nudGamePort.Value;
        set => nudGamePort.Value = value;
    }

    public int QueryPort
    {
        get => (int)nudQueryPort.Value;
        set => nudQueryPort.Value = value;
    }

    public int MaxPlayers
    {
        get => (int)nudSlotCount.Value;
        set => nudSlotCount.Value = value;
    }

    public string ShowPasswordButtonText
    {
        get => btnShowPassword.Text;
        set => btnShowPassword.Text = value;
    }

    public bool IsPasswordShown { get; set; }

    public char PasswordChar
    {
        get => txtServerPassword.PasswordChar;
        set => txtServerPassword.PasswordChar = value;
    }

    public event EventHandler ShowPasswordButtonClicked
    {
        add => btnShowPassword.Click += value;
        remove => btnShowPassword.Click -= value;
    }

    public event EventHandler SaveChangesButtonClicked
    {
        add => btnSaveSettings.Click += value;
        remove => btnSaveSettings.Click -= value;
    }
}
