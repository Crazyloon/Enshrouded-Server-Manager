using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Presenters;
public class DiscordNotificationsPresenter
{
    private readonly IDiscordNotificationsView _discordNotificationsView;
    private readonly IDiscordService _discordService;
    private readonly IMessageBoxService _messageBoxService;
    private readonly IProfileService _profileService;
    private readonly IFileSystemService _fileSystemService;

    public DiscordNotificationsPresenter(IDiscordNotificationsView discordNotificationsView,
        IDiscordService discordService,
        IMessageBoxService messageBoxService,
        IProfileService profileService,
        IFileSystemService fileSystemService)
    {
        _discordNotificationsView = discordNotificationsView;
        _discordService = discordService;
        _messageBoxService = messageBoxService;
        _profileService = profileService;

        _discordNotificationsView.SaveDiscordNotificationsSettingsClicked += OnSaveDiscordNotificationsSettingsClicked;
        _discordNotificationsView.TestDiscordMessageClicked += OnTestDiscordMessageClicked;
        _fileSystemService = fileSystemService;
    }

    private void OnTestDiscordMessageClicked(object? sender, EventArgs e)
    {
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string DiscordUrl = discordProfile.DiscordUrl;
            _discordService.TestMsg(DiscordUrl, discordProfile.EmbedEnabled);
        }
    }

    private void OnSaveDiscordNotificationsSettingsClicked(object? sender, EventArgs e)
    {
        var enabled = _discordNotificationsView.IsDiscordNotificationsEnabled;
        var startedEnabled = _discordNotificationsView.IsNotifyOnStartEnabled;
        var stoppedEnabled = _discordNotificationsView.IsNotifyOnStopEnabled;
        var updatingEnabled = _discordNotificationsView.IsNotifyOnUpdateEnabled;
        var backupEnabled = _discordNotificationsView.IsNotifyOnBackupEnabled;
        string url = _discordNotificationsView.WebhookUrl;
        string serverOnlineMsg = _discordNotificationsView.ServerStartedMessage;
        string serverStoppedMsg = _discordNotificationsView.ServerStoppedMessage;
        string serverUpdatingMsg = _discordNotificationsView.ServerUpdatingMessage;
        string backupMsg = _discordNotificationsView.BackupCreatedMessage;
        var embedEnabled = _discordNotificationsView.IsEmbedsEnabled;

        DiscordProfile discordProfile = new DiscordProfile()
        {
            DiscordUrl = url,
            Enabled = enabled,
            StartEnabled = startedEnabled,
            StopEnabled = stoppedEnabled,
            UpdatingEnabled = updatingEnabled,
            BackupEnabled = backupEnabled,
            EmbedEnabled = embedEnabled,
            ServerOnlineMsg = serverOnlineMsg,
            ServerStoppedMsg = serverStoppedMsg,
            ServerUpdatingMsg = serverUpdatingMsg,
            BackupMsg = backupMsg
        };

        // write the new discord profile to the json file
        var discordProfileJson = JsonConvert.SerializeObject(discordProfile, JsonSettings.Default);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);
        _fileSystemService.WriteFile(discordSettingsFile, discordProfileJson);

        // notify the view that the settings have been saved
        EventAggregator.Instance.Publish(new DiscordSettingsSavedMessage());
    }
}
