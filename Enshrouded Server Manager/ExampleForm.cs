using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using System.Net;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager;
public partial class ExampleForm : Form
{
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    private Panel pnlUpdateServerfiles;
    private Label lblUpdateServerfiles;

    public ExampleForm()
    {
        InitializeComponent();

        // initialize services
        var fileSystemManager = new FileSystemService();
        var profileManager = new ProfileService(fileSystemManager);
        var enshroudedServer = new EnshroudedServerService(fileSystemManager);
        var versionManager = new VersionManagementService(fileSystemManager);
        var discordOutputService = new DiscordOutputService();
        var processManager = new SystemProcessService();
        var messageBox = new MessageBoxService();
        var httpClient = new HttpClientService(new WebClient());
        var serverSettingsService = new ServerSettingsService(fileSystemManager, messageBox, enshroudedServer);
        var steamCMDInstaller = new SteamCMDInstallerService(fileSystemManager, processManager, messageBox, httpClient);

        adminPanelView.Tag = new AdminPanelPresenter(steamCMDInstaller, fileSystemManager, versionManager, processManager, serverSettingsService, enshroudedServer, profileManager, discordOutputService, adminPanelView);

        // Load the profiles for each view the first time they are created
        var profiles = profileManager.LoadServerProfiles(JsonSettings.Default, true);

        serverSettingsView.Tag = new ServerSettingsPresenter(serverSettingsView, serverSettingsService, fileSystemManager, enshroudedServer);
        profileSelectorView.Tag = new ProfileSelectorPresenter(profileSelectorView, profileManager, fileSystemManager, profiles);

        pnlUpdateServerfiles = new Panel();
        lblUpdateServerfiles = new Label();

        EventAggregator.Instance.Subscribe<ServerInstallStartedMessage>(m => OnServerInstallStarted());
        EventAggregator.Instance.Subscribe<ServerInstallStoppedMessage>(m => OnServerInstallStopped());

        InitializeServerUpdateOverlay();
    }

    private void OnServerInstallStopped()
    {
        pnlUpdateServerfiles.Visible = false;
    }

    private void OnServerInstallStarted()
    {
        pnlUpdateServerfiles.Visible = true;
    }

    private void pbxFormHeader_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, Constants.BUTTON_DOWN, Constants.CAPTION, 0);
        }
    }

    private void lblCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void lblMinimizeButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void InitializeServerUpdateOverlay()
    {
        // calculate the top left corner for the panel based on header height
        int pX = pbxLeftBorder.Width;
        int pY = pnlTopBorder.Location.Y + pnlTopBorder.Height;
        // calculate the width of the panel based off the left edge to the start of the infoPanel border
        int pWidth = pnlInfoPanel.Location.X + pnlRightPanel.Location.X - pX;
        // calculate the height of the panel based off the height of the form minus the offset of the top of the panel
        int pHeight = Height - pY - pbxBottomBorder.Height;

        // Label
        lblUpdateServerfiles.AutoSize = false;
        lblUpdateServerfiles.Dock = DockStyle.Fill;
        lblUpdateServerfiles.Location = new Point(0, 0);
        lblUpdateServerfiles.TextAlign = ContentAlignment.MiddleCenter;
        lblUpdateServerfiles.Text = "Updating Server Files...";
        lblUpdateServerfiles.Visible = true;

        // Panel
        pnlUpdateServerfiles.SuspendLayout();

        pnlUpdateServerfiles.BackColor = Color.FromArgb(0, 0, 18);
        pnlUpdateServerfiles.Controls.Add(lblUpdateServerfiles);
        pnlUpdateServerfiles.Location = new Point(pX, pY);
        pnlUpdateServerfiles.Size = new Size(pWidth, pHeight);
        pnlUpdateServerfiles.Visible = false;

        this.Controls.Add(pnlUpdateServerfiles);

        pnlUpdateServerfiles.BringToFront();
        pnlUpdateServerfiles.ResumeLayout(false);
        pnlUpdateServerfiles.PerformLayout();

    }
}
