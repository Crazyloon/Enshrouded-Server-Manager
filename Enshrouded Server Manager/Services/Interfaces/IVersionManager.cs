namespace Enshrouded_Server_Manager.Services.Interfaces;

public interface IVersionManager
{
    void ManagerUpdate(string currentVersionText, Label lblNewVersionText);
    void CheckManagerVersion(string currentVersionText, Label lblNewVersionText);
    Task ServerUpdateCheck(string selectedProfileName, Button btnUpdateServer);
}