using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;

public interface IServerSettingsService
{
    ServerSettings? LoadServerSettings(string selectedProfileName);
    bool SaveServerSettings(ServerSettings serverSettings, ServerProfile serverProfile);
}