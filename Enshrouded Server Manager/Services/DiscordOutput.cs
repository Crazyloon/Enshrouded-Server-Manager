using Discord;
using Discord.Webhook;

namespace Enshrouded_Server_Manager.Services;

class DiscordOutput
{
    // send server is online status to webhook
    public async Task ServerOnline(string SERVERNAME, string URL)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient($"{URL}");

        var embed = new EmbedBuilder
        {
            Title = $"Server {SERVERNAME}",
            Description = "Server is online!"
        };

        await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
    }

    // send server is offline status to webhook
    public async Task ServerOffline(string SERVERNAME, string URL)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient($"{URL}");

        var embed = new EmbedBuilder
        {
            Title = $"Server {SERVERNAME}",
            Description = "Server is offline!"
        };

        await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
    }

    // send server is updating status to webhook
    public async Task ServerUpdating(string SERVERNAME, string URL)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient($"{URL}");

        var embed = new EmbedBuilder
        {
            Title = $"Server {SERVERNAME}",
            Description = "Server is updating!"
        };

        await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
    }

    // send server backup has been created status to webhook
    public async Task ServerBackup(string SERVERNAME, string URL)
    {
        // The webhook url follows the format https://discord.com/api/webhooks/{id}/{token}
        using var client = new DiscordWebhookClient($"{URL}");

        var embed = new EmbedBuilder
        {
            Title = $"Server {SERVERNAME}",
            Description = "AutoBackup created!"
        };

        await client.SendMessageAsync(text: "", embeds: new[] { embed.Build() });
    }
}
