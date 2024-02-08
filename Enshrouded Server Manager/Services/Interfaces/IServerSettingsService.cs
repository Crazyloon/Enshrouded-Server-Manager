using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;

public interface IServerSettingsService
{
    ServerSettings? LoadServerSettings(string selectedProfileName);
    void SaveServerSettings(ServerSettings serverSettings, ServerProfile serverProfile);
}