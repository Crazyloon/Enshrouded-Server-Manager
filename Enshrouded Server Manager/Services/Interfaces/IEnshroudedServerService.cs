namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IEnshroudedServerService
{
    void Start(string pathServerExe, string selectedProfileName);
    void InstallUpdate(string steamAppId, string serverProfilePath, string selectedProfileName);
    void Stop(string selectedProfileName);
    bool IsRunning(string selectedProfileName);
}
