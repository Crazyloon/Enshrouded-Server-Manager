using Enshrouded_Server_Manager.Commands;
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

    public ExampleForm()
    {
        InitializeComponent();

        // initialize services
        var fileSystemManager = new FileSystemManager();
        var profileManager = new ProfileManager(fileSystemManager);
        var server = new Server(fileSystemManager);
        var processManager = new ProcessManager();
        var messageBox = new MessageBoxWrapper();
        var httpClient = new HttpClientService(new WebClient());
        var serverSettingsService = new ServerSettingsService(fileSystemManager, messageBox, server);
        var steamCMDInstaller = new SteamCMD(fileSystemManager, processManager, messageBox, httpClient);

        var commands = new IAdminPanelCommand[]
        {
            new InstallSteamCmdCommand(steamCMDInstaller, fileSystemManager),
            //new OpenWindowsFirewallCommand(new WindowsFirewallManager()),
            //new StartServerCommand(new Server()),
            //new StopServerCommand(new Server()),
            //new InstallServerCommand(new Server()),
            //new UpdateServerCommand(new Server()),
            //new SaveBackupCommand(new FileSystemManager()),
            //new OpenBackupFolderCommand(new FileSystemManager()),
            //new OpenSavegameFolderCommand(new FileSystemManager())
        };

        adminPanelView.Tag = new AdminPanelPresenter(steamCMDInstaller, fileSystemManager, server, commands, adminPanelView);

        // Load the profiles for each view the first time they are created
        var profiles = profileManager.LoadServerProfiles(JsonSettings.Default, true);

        serverSettingsView.Tag = new ServerSettingsPresenter(serverSettingsView, serverSettingsService, fileSystemManager, server);
        profileSelectorView.Tag = new ProfileSelectorPresenter(profileSelectorView, profileManager, fileSystemManager, profiles);

    }

    private void pbxFormHeader_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, Constants.BUTTON_DOWN, Constants.CAPTION, 0);
        }
    }
}
