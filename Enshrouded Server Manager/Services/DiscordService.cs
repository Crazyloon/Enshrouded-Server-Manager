using Discord;
using Discord.Webhook;
using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;

public class DiscordService : IDiscordService
{
    private IFileSystemService _fileSystemService;
    private IFileLoggerService _logger;
    private IEventAggregator _eventAggregator;

    public DiscordService(IFileSystemService fileSystemService,
        IFileLoggerService logger,
        IEventAggregator eventAggregator)
    {
        _fileSystemService = fileSystemService;
        _logger = logger;
        _eventAggregator = eventAggregator;
    }

    public void SendMessage(ServerProfile profile, DiscordMessageType messageType, string? timeLeft = null)
    {
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profile.Name);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string DiscordUrl = discordProfile.DiscordUrl;

            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            ServerSettings serverSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
            string name = serverSettings.Name;

            try
            {
                SendMessage(name, DiscordUrl, discordProfile, messageType, timeLeft);
            }
            catch
            {
                _logger.LogError($"Unable to send Discord {messageType} message for {profile.Name}");
            }
        }
    }

    private void SendMessage(string name, string url, DiscordProfile discordProfile, DiscordMessageType messageType, string? timeLeft = null)
    {
        if (!discordProfile.Enabled)
        {
            return;
        }

        switch (messageType)
        {
            case DiscordMessageType.ServerStarted:
                if (discordProfile.StartEnabled)
                {
                    ServerOnline(name, url, discordProfile.EmbedEnabled, discordProfile.ServerStartedMsg);
                }
                break;
            case DiscordMessageType.ServerStopped:
                if (discordProfile.StopEnabled)
                {
                    ServerOffline(name, url, discordProfile.EmbedEnabled, discordProfile.ServerStoppedMsg);
                }
                break;
            case DiscordMessageType.ServerUpdating:
                if (discordProfile.UpdatingEnabled)
                {
                    ServerUpdating(name, url, discordProfile.EmbedEnabled, discordProfile.ServerUpdatingMsg);
                }
                break;
            case DiscordMessageType.Backup:
                if (discordProfile.BackupEnabled)
                {
                    ServerBackup(name, url, discordProfile.EmbedEnabled, discordProfile.BackupMsg);
                }
                break;
            case DiscordMessageType.RestartImminent:
                if (discordProfile.RestartEnabled)
                {
                    ServerRestartImminent(name, url, discordProfile.EmbedEnabled, discordProfile.RestartMsg, timeLeft);
                }
                break;
            case DiscordMessageType.BackupRestored:
                if (discordProfile.BackupRestoreEnabled)
                {
                    ServerBackup(name, url, discordProfile.EmbedEnabled, discordProfile.BackupRestoreMsg);
                }
                break;
            default:
                break;
        }
    }

    // send server is online status to webhook
    public async Task ServerOnline(string serverName, string url, bool embedEnabled, string onlineMsg)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - {serverName} : {onlineMsg}",
                Description = "",
                Color = Discord.Color.Green
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - {serverName} : {onlineMsg}");
        }
    }

    // send server is offline status to webhook
    private async Task ServerOffline(string serverName, string url, bool embedEnabled, string offlineMsg)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }

        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - {serverName} : {offlineMsg}",
                Description = "",
                Color = Discord.Color.Red
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - {serverName} : {offlineMsg}");
        }
    }

    // send server is updating status to webhook
    private async Task ServerUpdating(string serverName, string url, bool embedEnabled, string updatingMsg)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }

        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - {serverName} : {updatingMsg}",
                Description = "",
                Color = Discord.Color.Gold
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - {serverName} : {updatingMsg}");
        }
    }

    // send server backup has been created status to webhook
    private async Task ServerBackup(string serverName, string url, bool embedEnabled, string backupMsg)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }

        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - {serverName} : {backupMsg}",
                Description = "",
                Color = Discord.Color.Blue
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - {serverName} : {backupMsg}");
        }
    }

    private async Task ServerRestartImminent(string serverName, string url, bool embedEnabled, string restartMsg, string? timeLeft)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }

        restartMsg = restartMsg.Replace("{TIME_LEFT}", timeLeft);

        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - {serverName} : {restartMsg}",
                Description = "",
                Color = Discord.Color.Blue
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - {serverName} : {restartMsg}");
        }
    }

    // send test msg to webhook
    public async Task TestMsg(string url, bool embedEnabled)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }

        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(url);

        if (embedEnabled == true)
        {
            var embed = new EmbedBuilder
            {
                Title = $"ESM - Test : Test",
                Description = "",
                Color = Discord.Color.Blue
            };
            await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
        }
        else
        {
            await client.SendMessageAsync(text: $"ESM - Test : Test");
        }
    }
}
