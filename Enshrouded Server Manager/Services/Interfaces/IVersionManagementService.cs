namespace Enshrouded_Server_Manager.Services;

public interface IVersionManagementService
{
    void ManagerUpdate(string currentVersionText);
    Task<Color> ServerUpdateCheck(string selectedProfileName);
    string SyncVersionText();
}