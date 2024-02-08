namespace Enshrouded_Server_Manager.Services.Interfaces;

public interface IVersionManagementService
{
    void ManagerUpdate(string currentVersionText, Label lblNewVersionText);
    void CheckManagerVersion(string currentVersionText, Label lblNewVersionText);
    Task<Color> ServerUpdateCheck(string selectedProfileName);
}