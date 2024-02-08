namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IServer
{
    void Start(string pathServerExe, string selectedProfileName);
    void InstallUpdate(string steamAppId, string serverProfilePath, string selectedProfileName, Button btnInstallServer, Button btnUpdateServer, Button btnStartServer);
    void Stop(string selectedProfileName);
    bool IsRunning(string selectedProfileName);
}
