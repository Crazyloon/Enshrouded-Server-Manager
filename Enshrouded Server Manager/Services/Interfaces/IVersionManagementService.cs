namespace Enshrouded_Server_Manager.Services;

public interface IVersionManagementService
{
    void ManagerUpdate(string currentVersionText);
    string SyncVersionText();
}