namespace Enshrouded_Server_Manager.Services;
public interface IFileLoggerService
{
    void LogInfo(string infoMessage);
    void LogWarning(string warningMessage);
    void LogError(string errorMessage);
}
