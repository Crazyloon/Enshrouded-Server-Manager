using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;

public interface IDiscordService
{
    Task SendMessageServerOnline(ServerProfile profile);
    Task SendMessageServerOffline(ServerProfile profile);
    Task SendMessageServerUpdating(ServerProfile profile);

    Task ServerOnline(string serverName, string Url, bool embedEnabled, string onlineMsg);
    Task ServerOffline(string serverName, string Url, bool embedEnabled, string offlineMsg);
    Task ServerUpdating(string serverName, string Url, bool embedEnabled, string updatingMsg);
    Task ServerBackup(string serverName, string Url, bool embedEnabled, string backupMsg);
    Task TestMsg(string Url, bool embedEnabled);

}