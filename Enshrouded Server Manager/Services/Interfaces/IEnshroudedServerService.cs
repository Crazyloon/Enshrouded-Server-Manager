using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;
public interface IEnshroudedServerService
{
    void Start(string pathServerExe, ServerProfile serverProfile);
    void Stop(ServerProfile serverProfile);
    void InstallUpdate(string steamAppId, string serverProfilePath, string selectedProfileName);
    bool IsRunning(string selectedProfileName);
}
