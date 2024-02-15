using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;
public interface IEnshroudedServerService
{
    void Start(string pathServerExe, string selectedProfileName);
    void Stop(string selectedProfileName);
    CountDownTimer StartScheduledRestarts(ServerProfile severProfile);
    void InstallUpdate(string steamAppId, string serverProfilePath, string selectedProfileName);
    bool IsRunning(string selectedProfileName);
}
