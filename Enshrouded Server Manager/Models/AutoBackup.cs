namespace Enshrouded_Server_Manager.Models;
public class AutoBackup
{
    public int Interval { get; set; }
    public int MaxiumBackups { get; set; }
    public DateTime LastBackup { get; set; }
    public bool Enabled { get; set; }
}
