using Discord;
using Discord.Webhook;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Model;
using Enshrouded_Server_Manager.Models;
using Newtonsoft.Json;

namespace Enshrouded_Server_Manager.Services;

public class DiscordService : IDiscordService
{
    private IFileSystemService _fileSystemService;
    private IFileLoggerService _logger;


    public DiscordService(IFileSystemService fileSystemService,
        IFileLoggerService logger)
    {
        _fileSystemService = fileSystemService;
        _logger = logger;
    }

    public async Task SendMessageServerOnline(ServerProfile profile)
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

            if (discordProfile.Enabled)
            {
                if (discordProfile.StartEnabled)
                {
                    try
                    {
                        ServerOnline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerStartedMsg);
                    }
                    catch
                    {
                        // TODO: Raise an erorr event/Report an error message
                    }
                }
            }
        }
    }

    public async Task SendMessageServerOffline(ServerProfile profile)
    {
        // discord Output
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profile.Name);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string DiscordUrl = discordProfile.DiscordUrl;

            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
            string name = gameServerSettings.Name;

            if (discordProfile.Enabled)
            {
                if (discordProfile.StopEnabled)
                {
                    try
                    {
                        ServerOffline(name, DiscordUrl, discordProfile.EmbedEnabled, discordProfile.ServerStoppedMsg);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }

    public async Task SendMessageServerUpdating(ServerProfile profile)
    {
        var serverProfilePath = Path.Join(Constants.Paths.SERVER_DIRECTORY, profile.Name);
        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_DIRECTORY, Constants.Files.DISCORD_JSON);
        if (_fileSystemService.FileExists(discordSettingsFile))
        {
            var discordSettingsText = _fileSystemService.ReadFile(discordSettingsFile);
            DiscordProfile discordProfile = JsonConvert.DeserializeObject<DiscordProfile>(discordSettingsText, JsonSettings.Default);
            string discordUrl = discordProfile.DiscordUrl;

            var gameServerConfig = Path.Join(serverProfilePath, Constants.Files.GAME_SERVER_CONFIG_JSON);
            var gameServerConfigText = _fileSystemService.ReadFile(gameServerConfig);
            ServerSettings gameServerSettings = JsonConvert.DeserializeObject<ServerSettings>(gameServerConfigText, JsonSettings.Default);
            string name = gameServerSettings.Name;

            if (discordProfile.Enabled)
            {
                if (discordProfile.UpdatingEnabled)
                {

                    try
                    {
                        ServerUpdating(name, discordUrl, discordProfile.EmbedEnabled, discordProfile.ServerUpdatingMsg);
                    }
                    catch
                    {

                    }
                }
            }
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
    public async Task ServerOffline(string serverName, string url, bool embedEnabled, string offlineMsg)
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
    public async Task ServerUpdating(string serverName, string url, bool embedEnabled, string updatingMsg)
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
    public async Task ServerBackup(string serverName, string url, bool embedEnabled, string backupMsg)
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
