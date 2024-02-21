namespace Enshrouded_Server_Manager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        //Application.Run(new MainForm());
        Application.Run(new NewUIForm());
    }

    //public static IServiceProvider ServiceProvider { get; private set; }
    //static IHostBuilder CreateHostBuilder()
    //{
    //    Dictionary<string, CountDownTimer> restartTimers = new();

    //    return Host.CreateDefaultBuilder()
    //        .ConfigureServices((_, services) =>
    //        {
    //            services.AddTransient<IBackupService, BackupService>();
    //            services.AddTransient<IDiscordService, DiscordService>();
    //            services.AddTransient<IEnshroudedServerService, EnshroudedServerService>();
    //            services.AddTransient<IFileLoggerService, FileLogger>();
    //            services.AddTransient<IFileSystemService, FileSystemService>();
    //            services.AddTransient<WebClient>();
    //            services.AddTransient<IHttpClientService, HttpClientService>();
    //            services.AddTransient<IMessageBoxService, MessageBoxService>();
    //            services.AddTransient<IProfileService, ProfileService>();
    //            services.AddTransient<IServerSettingsService, ServerSettingsService>();
    //            services.AddTransient<ISteamCMDInstallerService, SteamCMDInstallerService>();
    //            services.AddTransient<ISystemProcessService, SystemProcessService>();
    //            services.AddTransient<IVersionManagementService, VersionManagementService>();
    //            services.AddTransient<IScheduledRestartService, ScheduledRestartService>();

    //            services.AddTransient<MainForm>();

    //            services.AddSingleton<Dictionary<string, CountDownTimer>>(new Dictionary<string, CountDownTimer>());

    //            services.AddSingleton<IEventAggregator, EventAggregator>();
    //        });
    //}
}