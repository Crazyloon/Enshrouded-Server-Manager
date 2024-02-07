namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IServer
{
    void Start(string pathServerExe, string selectedProfileName);
    void InstallUpdate(string steamAppId, string serverProfilePath);
    void Stop(string selectedProfileName);
    bool IsRunning(string selectedProfileName);
}
