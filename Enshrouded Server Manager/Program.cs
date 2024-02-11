namespace Enshrouded_Server_Manager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        //// initialize services
        //var fileSystemManager = new FileSystemManager();
        //var processManager = new ProcessManager();
        //var messageBox = new MessageBoxWrapper();
        //var httpClient = new HttpClientService(new WebClient());
        //var profileManager = new ProfileManager(fileSystemManager);
        //var server = new Server(fileSystemManager);
        //var serverSettingsService = new ServerSettingsService(fileSystemManager);
        //var steamCMDInstaller = new SteamCMD(fileSystemManager, processManager, messageBox, httpClient);

        //var commands = new IAdminPanelCommand[]
        //{
        //    new InstallSteamCmdCommand(steamCMDInstaller, fileSystemManager),
        //    //new OpenWindowsFirewallCommand(new WindowsFirewallManager()),
        //    //new StartServerCommand(new Server()),
        //    //new StopServerCommand(new Server()),
        //    //new InstallServerCommand(new Server()),
        //    //new UpdateServerCommand(new Server()),
        //    //new SaveBackupCommand(new FileSystemManager()),
        //    //new OpenBackupFolderCommand(new FileSystemManager()),
        //    //new OpenSavegameFolderCommand(new FileSystemManager())
        //};

        //// initialize views
        //var adminPanelView = new AdminPanelView();
        //var profileSelectorView = new ProfileSelectorView();
        //var serverSettingsView = new ServerSettingsView();
        //var autoBackupView = new AutoBackupView();
        //var discordNotificationsView = new DiscordNotificationsView();
        //var infoPanelView = new InfoPanelView();
        //var manageProfilesView = new ManageProfilesView();


        //adminPanelView.Tag = new AdminPanelPresenter(steamCMDInstaller, fileSystemManager, server, commands, adminPanelView);

        //// Load the profiles for each view the first time they are created
        //var profiles = profileManager.LoadServerProfiles(JsonSettings.Default, true);

        //profileSelectorView.Tag = new ProfileSelectorPresenter(profileSelectorView, profileManager, fileSystemManager, profiles);



        //Application.Run(
        //    new ExampleForm(adminPanelView,
        //    profileSelectorView,
        //    infoPanelView,
        //    serverSettingsView,
        //    manageProfilesView,
        //    autoBackupView,
        //    discordNotificationsView)
        //);

        Application.Run(new MainForm());
    }
}