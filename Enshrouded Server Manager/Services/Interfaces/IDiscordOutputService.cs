namespace Enshrouded_Server_Manager.Services;

public interface IDiscordOutputService
{
    Task ServerOnline(string serverName, string Url, bool embedEnabled, string onlineMsg);
    Task ServerOffline(string serverName, string Url, bool embedEnabled, string offlineMsg);
    Task ServerUpdating(string serverName, string Url, bool embedEnabled, string updatingMsg);
    Task ServerBackup(string serverName, string Url, bool embedEnabled, string backupMsg);
    Task TestMsg(string Url, bool embedEnabled);

}