namespace Enshrouded_Server_Manager.Services;
public interface IFileLogger
{
    void LogInfo(string infoMessage);
    void LogWarning(string warningMessage);
    void LogError(string errorMessage);
}
