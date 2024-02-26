using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;
public interface IEnshroudedServerService
{
    void Start(string pathServerExe, ServerProfile serverProfile);
    void Stop(ServerProfile serverProfile);
    void Install(string serverProfilePath);
    void Update();
    bool IsRunning(string selectedProfileName);
    Task<Color> ServerUpdateCheck(string selectedProfileName);
}
