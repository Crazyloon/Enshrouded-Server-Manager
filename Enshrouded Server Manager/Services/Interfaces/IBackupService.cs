using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Services;

public interface IBackupService
{
    void Save(string saveFileDirectory, ServerProfile profile, string serverConfigFileName, string serverConfigDirectory);
    void StartAutoBackup(string saveFileDirectory, ServerProfile profile, int interval, int maximumBackups, string serverConfigFileName, string serverConfigDirectory);
    bool RestoreBackup(ServerProfile profile, string backupFilePath);
    int GetBackupCount(ServerProfile profile);
    long GetDiskConsumption(ServerProfile profile);
}