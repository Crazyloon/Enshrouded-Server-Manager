using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Presenters;
public class DiscordNotificationsPresenter
{
    private readonly IDiscordNotificationsView _discordNotificationsView;
    private readonly IEventAggregator _eventAggregator;
    private readonly IDiscordService _discordService;
    private readonly IMessageBoxService _messageBoxService;
    private readonly IProfileService _profileService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IFileLoggerService _logger;

    private DiscordProfile _discordProfile;

    public DiscordNotificationsPresenter(IDiscordNotificationsView discordNotificationsView,
        IEventAggregator eventAggregator,
        IDiscordService discordService,
        IMessageBoxService messageBoxService,
        IProfileService profileService,
        IFileSystemService fileSystemService,
        IFileLoggerService fileLogger)
    {
        _discordNotificationsView = discordNotificationsView;
        _eventAggregator = eventAggregator;
        _discordService = discordService;
        _messageBoxService = messageBoxService;
        _profileService = profileService;
        _fileSystemService = fileSystemService;
        _logger = fileLogger;

        _discordNotificationsView.DiscordSettingsLoad += OnLoad;
        _discordNotificationsView.SaveDiscordNotificationsSettingsClicked += OnSaveDiscordNotificationsSettingsClicked;
        _discordNotificationsView.TestDiscordMessageClicked += OnTestDiscordMessageClicked;

        _eventAggregator.Subscribe<ServerResetTimerUpdatedMessage>(p => OnServerTimerUpdated(p.ServerProfile, p.TimeLeft));

        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        if (!_fileSystemService.FileExists(discordSettingsFile))
        {
            return;
        }

        var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
        _discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
    }
    private void OnServerTimerUpdated(ServerProfile profile, string timeRemaining)
    {
        // timeRemaining has the format d.hh:mm:ss
        if (int.TryParse(timeRemaining.Split('.')[0], out int days) && days > 0)
        {
            return;
        }

        var realTime = TimeSpan.Parse(timeRemaining.Split('.')[1]);

        // Hack an extra second in to make it easier to check for the time
        // when resets are schedueld at exactly 2 hours or 1 hour
        // because this method is called every second after the timer changes
        // and the first change on a 2hr timer is 1:59:59
        realTime = realTime.Add(TimeSpan.FromSeconds(1));

        if (realTime <= TimeSpan.FromHours(2))
        {
            bool sendMessage = false;
            string message = "";
            switch (realTime)
            {
                case TimeSpan t when realTime == TimeSpan.FromHours(2):
                    sendMessage = _discordProfile.LongResetEnabled;
                    message = "120";
                    break;
                case TimeSpan t when realTime == TimeSpan.FromHours(1):
                    sendMessage = _discordProfile.MediumResetEnabled;
                    message = "60";
                    break;
                case TimeSpan t when realTime == TimeSpan.FromMinutes(30):
                    sendMessage = _discordProfile.ShortResetEnabled;
                    message = "30";
                    break;
                case TimeSpan t when realTime == TimeSpan.FromMinutes(10):
                    sendMessage = _discordProfile.SoonResetEnabled;
                    message = "10";
                    break;
                case TimeSpan t when realTime == TimeSpan.FromMinutes(5):
                    sendMessage = _discordProfile.ImminentResetEnabled;
                    message = "5";
                    break;
                default:
                    break;
            }

            if (sendMessage)
            {
                _discordService.SendMessage(profile, DiscordMessageType.RestartImminent, message);
            }
        }

    }

    private void OnLoad(object? sender, EventArgs e)
    {
        if (_discordProfile is not null)
        {
            _discordNotificationsView.IsDiscordNotificationsEnabled = _discordProfile.Enabled;
            _discordNotificationsView.IsNotifyOnStartEnabled = _discordProfile.StartEnabled;
            _discordNotificationsView.IsNotifyOnStopEnabled = _discordProfile.StopEnabled;
            _discordNotificationsView.IsNotifyOnUpdateEnabled = _discordProfile.UpdatingEnabled;
            _discordNotificationsView.IsNotifyOnBackupEnabled = _discordProfile.BackupEnabled;
            _discordNotificationsView.IsNotifyOnBackupRestoreEnabled = _discordProfile.BackupRestoreEnabled;
            _discordNotificationsView.IsNotifyOnServerRestartEnabled = _discordProfile.RestartEnabled;
            _discordNotificationsView.WebhookUrl = _discordProfile.DiscordUrl;
            _discordNotificationsView.ServerStartedMessage = _discordProfile.ServerStartedMsg;
            _discordNotificationsView.ServerStoppedMessage = _discordProfile.ServerStoppedMsg;
            _discordNotificationsView.ServerUpdatingMessage = _discordProfile.ServerUpdatingMsg;
            _discordNotificationsView.BackupCreatedMessage = _discordProfile.BackupMsg;
            _discordNotificationsView.BackupRestoredMessage = _discordProfile.BackupRestoreMsg;
            _discordNotificationsView.ServerRestartMessage = _discordProfile.RestartMsg;
            _discordNotificationsView.IsEmbedsEnabled = _discordProfile.EmbedEnabled;
            _discordNotificationsView.IsLongResetMessageEnabled = _discordProfile.LongResetEnabled;
            _discordNotificationsView.IsMediumResetMessageEnabled = _discordProfile.MediumResetEnabled;
            _discordNotificationsView.IsShortResetMessageEnabled = _discordProfile.ShortResetEnabled;
            _discordNotificationsView.IsSoonResetMessageEnabled = _discordProfile.SoonResetEnabled;
            _discordNotificationsView.IsImminentResetMessageEnabled = _discordProfile.ImminentResetEnabled;
        }
    }

    private void OnTestDiscordMessageClicked(object? sender, EventArgs e)
    {
        if (_discordProfile is not null)
        {
            _discordService.TestMsg(_discordProfile.DiscordUrl, _discordProfile.EmbedEnabled);
        }
    }

    private void OnSaveDiscordNotificationsSettingsClicked(object? sender, EventArgs e)
    {
        bool enabled = _discordNotificationsView.IsDiscordNotificationsEnabled;
        bool startedEnabled = _discordNotificationsView.IsNotifyOnStartEnabled;
        bool stoppedEnabled = _discordNotificationsView.IsNotifyOnStopEnabled;
        bool updatingEnabled = _discordNotificationsView.IsNotifyOnUpdateEnabled;
        bool backupEnabled = _discordNotificationsView.IsNotifyOnBackupEnabled;
        bool restoreEnabled = _discordNotificationsView.IsNotifyOnBackupRestoreEnabled;
        bool restartEnabled = _discordNotificationsView.IsNotifyOnServerRestartEnabled;
        string url = _discordNotificationsView.WebhookUrl;
        string serverOnlineMsg = _discordNotificationsView.ServerStartedMessage;
        string serverStoppedMsg = _discordNotificationsView.ServerStoppedMessage;
        string serverUpdatingMsg = _discordNotificationsView.ServerUpdatingMessage;
        string backupMsg = _discordNotificationsView.BackupCreatedMessage;
        string restoreMsg = _discordNotificationsView.BackupRestoredMessage;
        string restartMessage = _discordNotificationsView.ServerRestartMessage;
        bool embedEnabled = _discordNotificationsView.IsEmbedsEnabled;

        bool longResetEnabled = _discordNotificationsView.IsLongResetMessageEnabled;
        bool mediumResetEnabled = _discordNotificationsView.IsMediumResetMessageEnabled;
        bool shortResetEnabled = _discordNotificationsView.IsShortResetMessageEnabled;
        bool soonResetEnabled = _discordNotificationsView.IsSoonResetMessageEnabled;
        bool imminentResetEnabled = _discordNotificationsView.IsImminentResetMessageEnabled;


        _discordProfile = new DiscordProfile()
        {
            DiscordUrl = url,
            Enabled = enabled,
            EmbedEnabled = embedEnabled,
            StartEnabled = startedEnabled,
            StopEnabled = stoppedEnabled,
            UpdatingEnabled = updatingEnabled,
            BackupEnabled = backupEnabled,
            BackupRestoreEnabled = restoreEnabled,
            RestartEnabled = restartEnabled,
            ServerStartedMsg = serverOnlineMsg,
            ServerStoppedMsg = serverStoppedMsg,
            ServerUpdatingMsg = serverUpdatingMsg,
            BackupMsg = backupMsg,
            BackupRestoreMsg = restoreMsg,
            RestartMsg = restartMessage,
            LongResetEnabled = longResetEnabled,
            MediumResetEnabled = mediumResetEnabled,
            ShortResetEnabled = shortResetEnabled,
            SoonResetEnabled = soonResetEnabled,
            ImminentResetEnabled = imminentResetEnabled
        };

        // write the new discord profile to the json file
        var discordProfileJson = JsonConvert.SerializeObject(_discordProfile, JsonSettings.Default);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        _fileSystemService.WriteFile(discordSettingsFile, discordProfileJson);

        // notify the view that the settings have been saved
        _discordNotificationsView.AnimateSaveButton();
    }
}
