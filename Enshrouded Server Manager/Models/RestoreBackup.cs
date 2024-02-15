namespace Enshrouded_Server_Manager.Models;
public class RestoreBackup
{
    public string BackupFilePath { get; set; }
    public bool RestoreOnScheduledRestart { get; set; }
}
