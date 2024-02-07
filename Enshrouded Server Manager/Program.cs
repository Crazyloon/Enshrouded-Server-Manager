using Enshrouded_Server_Manager.Commands;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using System.Net;

namespace Enshrouded_Server_Manager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // initialize services
        var fileSystemManager = new FileSystemManager();
        var processManager = new ProcessManager();
        var messageBox = new MessageBoxWrapper();
        var httpClient = new HttpClientService(new WebClient());
        var server = new Server(fileSystemManager);
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

        // initialize view
        var adminPanelView = new AdminPanelView();
        adminPanelView.SetCommands(commands);

        adminPanelView.Tag = new AdminPanelPresenter(steamCMDInstaller, fileSystemManager, server, adminPanelView);



        Application.Run(new Form1(adminPanelView));
    }
}