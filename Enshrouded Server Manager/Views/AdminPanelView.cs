using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager.Views;
public partial class AdminPanelView : UserControl, IAdminPanelView
{
    public AdminPanelView()
    {
        InitializeComponent();
    }

    #region EventHandlers
    public event EventHandler InstallSteamCMDButtonClicked
    {
        add => btnInstallSteamCMD.Click += value;
        remove => btnInstallSteamCMD.Click -= value;
    }
    public event EventHandler WindowsFirewallButtonClicked
    {
        add => btnWindowsFirewall.Click += value;
        remove => btnWindowsFirewall.Click -= value;
    }
    public event EventHandler StartServerButtonClicked
    {
        add => btnStartServer.Click += value;
        remove => btnStartServer.Click -= value;
    }
    public event EventHandler StopServerButtonClicked
    {
        add => btnStopServer.Click += value;
        remove => btnStopServer.Click -= value;
    }
    public event EventHandler InstallServerButtonClicked
    {
        add => btnInstallServer.Click += value;
        remove => btnInstallServer.Click -= value;
    }
    public event EventHandler UpdateServerButtonClicked
    {
        add => btnUpdateServer.Click += value;
        remove => btnUpdateServer.Click -= value;
    }
    public event EventHandler SaveBackupButtonClicked
    {
        add => btnSaveBackup.Click += value;
        remove => btnSaveBackup.Click -= value;
    }
    public event EventHandler OpenBackupFolderButtonClicked
    {
        add => btnOpenBackupFolder.Click += value;
        remove => btnOpenBackupFolder.Click -= value;
    }
    public event EventHandler OpenSavegameFolderButtonClicked
    {
        add => btnOpenSavegameFolder.Click += value;
        remove => btnOpenSavegameFolder.Click -= value;
    }
    public event EventHandler OpenLogFolderButtonClicked
    {
        add => btnOpenLogFolder.Click += value;
        remove => btnOpenLogFolder.Click -= value;
    }
    #endregion EventHandlers

    #region ButtonStateProperties
    public bool InstallSteamCMDButtonEnabled
    {
        get => btnInstallSteamCMD.Enabled;
        set => btnInstallSteamCMD.Enabled = value;
    }

    public bool InstallSteamCMDButtonVisible
    {
        get => btnInstallSteamCMD.Visible;
        set => btnInstallSteamCMD.Visible = value;
    }

    public bool WindowsFirewallButtonEnabled
    {
        get => btnWindowsFirewall.Enabled;
        set => btnWindowsFirewall.Enabled = value;
    }

    public bool WindowsFirewallButtonVisible
    {
        get => btnWindowsFirewall.Visible;
        set => btnWindowsFirewall.Visible = value;
    }

    public bool StartServerButtonEnabled
    {
        get => btnStartServer.Enabled;
        set => btnStartServer.Enabled = value;
    }

    public bool StartServerButtonVisible
    {
        get => btnStartServer.Visible;
        set => btnStartServer.Visible = value;
    }

    public bool StopServerButtonVisible
    {
        get => btnStopServer.Visible;
        set => btnStopServer.Visible = value;
    }

    public bool StopServerButtonEnabled
    {
        get => btnStopServer.Enabled;
        set => btnStopServer.Enabled = value;
    }

    public bool InstallServerButtonVisible
    {
        get => btnInstallServer.Visible;
        set => btnInstallServer.Visible = value;
    }

    public bool InstallServerButtonEnabled
    {
        get => btnInstallServer.Enabled;
        set => btnInstallServer.Enabled = value;
    }

    public bool UpdateServerButtonVisible
    {
        get => btnUpdateServer.Visible;
        set => btnUpdateServer.Visible = value;
    }

    public bool UpdateServerButtonEnabled
    {
        get => btnUpdateServer.Enabled;
        set => btnUpdateServer.Enabled = value;
    }

    public Color UpdateServerButtonBorderColor
    {
        get => btnUpdateServer.FlatAppearance.BorderColor;
        set => btnUpdateServer.FlatAppearance.BorderColor = value;
    }

    public bool SaveBackupButtonVisible
    {
        get => btnSaveBackup.Visible;
        set => btnSaveBackup.Visible = value;
    }

    public bool SaveBackupButtonEnabled
    {
        get => btnSaveBackup.Enabled;
        set => btnSaveBackup.Enabled = value;
    }

    public bool OpenBackupFolderButtonVisible
    {
        get => btnOpenBackupFolder.Visible;
        set => btnOpenBackupFolder.Visible = value;
    }

    public bool OpenBackupFolderButtonEnabled
    {
        get => btnOpenBackupFolder.Enabled;
        set => btnOpenBackupFolder.Enabled = value;
    }

    public bool OpenSavegameFolderButtonVisible
    {
        get => btnOpenSavegameFolder.Visible;
        set => btnOpenSavegameFolder.Visible = value;
    }

    public bool OpenSavegameFolderButtonEnabled
    {
        get => btnOpenSavegameFolder.Enabled;
        set => btnOpenSavegameFolder.Enabled = value;
    }

    public bool OpenLogFolderButtonVisible
    {
        get => btnOpenLogFolder.Visible;
        set => btnOpenLogFolder.Visible = value;
    }

    public bool OpenLogFolderButtonEnabled
    {
        get => btnOpenLogFolder.Enabled;
        set => btnOpenLogFolder.Enabled = value;
    }
    #endregion ButtonStateProperties

    private void gbxServerSpecificControls_Paint(object sender, PaintEventArgs e)
    {
        GroupBox box = (GroupBox)sender;
        e.Graphics.Clear(Color.FromArgb(0, 0, 18));
        var pen = new Pen(Color.FromArgb(0, 0, 18), 0.5f);
        var borderPen = new Pen(SystemBrushes.ControlDarkDark, 0.5f);
        var brush = new SolidBrush(Color.FromArgb(0, 0, 18));
        var fontHeight = (int)Math.Round(e.Graphics.MeasureString(box.Text, box.Font).Height);
        var textWidth = e.Graphics.MeasureString(box.Text, box.Font).Width;
        var textPaddingVertical = 2;
        var textPaddingHorizontal = 3;

        //e.Graphics.FillRectangle(brush, 0, 0, box.Width - 1, box.Height - 1); // fill the background
        e.Graphics.DrawRectangle(borderPen, 0, 8, box.Width - 1, box.Height - 10); // draw the border

        e.Graphics.FillRectangle(brush, 3, 0, textWidth + textPaddingHorizontal, box.Font.Height); // draw the text background
        e.Graphics.DrawString(box.Text, box.Font, SystemBrushes.ControlLight, fontHeight / 2 - textPaddingVertical, 0); // draw the text
    }

    private void SetDefaultButtonStates()
    {
        InstallSteamCMDButtonEnabled = true;
        InstallSteamCMDButtonVisible = true;

        WindowsFirewallButtonEnabled = true;
        WindowsFirewallButtonVisible = true;

        StartServerButtonEnabled = true;
        StartServerButtonVisible = true;

        StopServerButtonEnabled = true;
        StopServerButtonVisible = true;

        InstallServerButtonEnabled = true;
        InstallServerButtonVisible = true;

        UpdateServerButtonEnabled = true;
        UpdateServerButtonVisible = false;
        UpdateServerButtonBorderColor = Constants.Colors.BUTTON_BORDER;

        SaveBackupButtonEnabled = true;
        SaveBackupButtonVisible = true;

        OpenBackupFolderButtonEnabled = true;
        OpenBackupFolderButtonVisible = true;

        OpenSavegameFolderButtonEnabled = true;
        OpenSavegameFolderButtonVisible = true;

        OpenLogFolderButtonEnabled = true;
        OpenLogFolderButtonVisible = true;
    }

    private void AdminPanelView_Load(object sender, EventArgs e)
    {
        //SetDefaultButtonStates();
    }

    private void btnUpdateServer_EnabledChanged(object sender, EventArgs e)
    {
        var Sender = ((Button)sender);
        Sender.BackColor = Sender.Enabled ? Constants.Colors.BUTTON_BACKGROUND : Constants.Colors.BUTTON_BACKGROUND_DISABLED;

        // Reduce the opacity of the border color when the button is disabled
        var currentColor = Sender.FlatAppearance.BorderColor;
        var alpha = currentColor.A;
        var red = currentColor.R;
        var green = currentColor.G;
        var blue = currentColor.B;

        var disabledColor = Color.FromArgb((int)(alpha * 0.9f), red, green, blue);

        Sender.FlatAppearance.BorderColor = Sender.Enabled ? currentColor : disabledColor;
    }
}
