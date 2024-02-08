using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager.Views;
public partial class AdminPanelView : UserControl, IAdminPanelView
{
    #region PrivateMembers
    private AdminButtonState _installSteamCMDButtonState;
    private AdminButtonState _windowsFirewallButtonState;
    private AdminButtonState _startServerButtonState;
    private AdminButtonState _stopServerButtonState;
    private AdminButtonState _installServerButtonState;
    private AdminButtonState _updateServerButtonState;
    private AdminButtonState _saveBackupButtonState;
    private AdminButtonState _openBackupFolderButtonState;
    private AdminButtonState _openSavegameFolderButtonState;
    private AdminButtonState _openLogFolderButtonState;
    #endregion PrivateMembers

    public AdminPanelView()
    {
        InitializeComponent();
        SetDefaultButtonStates();
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
    public AdminButtonState InstallSteamCMDButtonState
    {
        get => _installSteamCMDButtonState;
        set
        {
            _installSteamCMDButtonState = value;
            btnInstallSteamCMD.Enabled = value.Enabled;
            btnInstallSteamCMD.Visible = value.Visible;
            btnInstallSteamCMD.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState WindowsFirewallButtonState
    {
        get => _windowsFirewallButtonState;
        set
        {
            _windowsFirewallButtonState = value;
            btnWindowsFirewall.Enabled = value.Enabled;
            btnWindowsFirewall.Visible = value.Visible;
            btnWindowsFirewall.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState StartServerButtonState
    {
        get => _startServerButtonState;
        set
        {
            _startServerButtonState = value;
            btnStartServer.Enabled = value.Enabled;
            btnStartServer.Visible = value.Visible;
            btnStartServer.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState StopServerButtonState
    {
        get => _stopServerButtonState;
        set
        {
            _stopServerButtonState = value;
            btnStopServer.Enabled = value.Enabled;
            btnStopServer.Visible = value.Visible;
            btnStopServer.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState InstallServerButtonState
    {
        get => _installServerButtonState;
        set
        {
            _installServerButtonState = value;
            btnInstallServer.Enabled = value.Enabled;
            btnInstallServer.Visible = value.Visible;
            btnInstallServer.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState UpdateServerButtonState
    {
        get => _updateServerButtonState;
        set
        {
            _updateServerButtonState = value;
            btnUpdateServer.Enabled = value.Enabled;
            btnUpdateServer.Visible = value.Visible;
            btnUpdateServer.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState SaveBackupButtonState
    {
        get => _saveBackupButtonState;
        set
        {
            _saveBackupButtonState = value;
            btnSaveBackup.Enabled = value.Enabled;
            btnSaveBackup.Visible = value.Visible;
            btnSaveBackup.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState OpenBackupFolderButtonState
    {
        get => _openBackupFolderButtonState;
        set
        {
            _openBackupFolderButtonState = value;
            btnOpenBackupFolder.Enabled = value.Enabled;
            btnOpenBackupFolder.Visible = value.Visible;
            btnOpenBackupFolder.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState OpenSavegameFolderButtonState
    {
        get => _openSavegameFolderButtonState;
        set
        {
            _openSavegameFolderButtonState = value;
            btnOpenSavegameFolder.Enabled = value.Enabled;
            btnOpenSavegameFolder.Visible = value.Visible;
            btnOpenSavegameFolder.FlatAppearance.BorderColor = value.BorderColor;
        }
    }
    public AdminButtonState OpenLogFolderButtonState
    {
        get => _openLogFolderButtonState;
        set
        {
            _openLogFolderButtonState = value;
            btnOpenLogFolder.Enabled = value.Enabled;
            btnOpenLogFolder.Visible = value.Visible;
            btnOpenLogFolder.FlatAppearance.BorderColor = value.BorderColor;
        }
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
        _installSteamCMDButtonState = new AdminButtonState
        {
            Enabled = btnInstallSteamCMD.Enabled,
            Visible = btnInstallSteamCMD.Visible,
            BorderColor = btnInstallSteamCMD.FlatAppearance.BorderColor
        };
        _windowsFirewallButtonState = new AdminButtonState
        {
            Enabled = btnWindowsFirewall.Enabled,
            Visible = btnWindowsFirewall.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _startServerButtonState = new AdminButtonState
        {
            Enabled = btnStartServer.Enabled,
            Visible = btnStartServer.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _stopServerButtonState = new AdminButtonState
        {
            Enabled = btnStopServer.Enabled,
            Visible = btnStopServer.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _installServerButtonState = new AdminButtonState
        {
            Enabled = btnInstallServer.Enabled,
            Visible = btnInstallServer.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _updateServerButtonState = new AdminButtonState
        {
            Enabled = btnUpdateServer.Enabled,
            Visible = btnUpdateServer.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _saveBackupButtonState = new AdminButtonState
        {
            Enabled = btnSaveBackup.Enabled,
            Visible = btnSaveBackup.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _openBackupFolderButtonState = new AdminButtonState
        {
            Enabled = btnOpenBackupFolder.Enabled,
            Visible = btnOpenBackupFolder.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _openSavegameFolderButtonState = new AdminButtonState
        {
            Enabled = btnOpenSavegameFolder.Enabled,
            Visible = btnOpenSavegameFolder.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
        _openLogFolderButtonState = new AdminButtonState
        {
            Enabled = btnOpenLogFolder.Enabled,
            Visible = btnOpenLogFolder.Visible,
            BorderColor = Constants.Colors.BUTTON_BORDER
        };
    }
}
