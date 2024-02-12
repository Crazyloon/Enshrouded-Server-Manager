using Discord;
using Discord.Webhook;

namespace Enshrouded_Server_Manager.Services;

public class DiscordService : IDiscordService
{
    // send server is online status to webhook
    public async Task ServerOnline(string serverName, string Url, bool embedEnabled, string onlineMsg)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(Url);

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
    public async Task ServerOffline(string serverName, string Url, bool embedEnabled, string offlineMsg)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(Url);

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
    public async Task ServerUpdating(string serverName, string Url, bool embedEnabled, string updatingMsg)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(Url);

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
    public async Task ServerBackup(string serverName, string Url, bool embedEnabled, string backupMsg)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(Url);

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
    public async Task TestMsg(string Url, bool embedEnabled)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient(Url);

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
