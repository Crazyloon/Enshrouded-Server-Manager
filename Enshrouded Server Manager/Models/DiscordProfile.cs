namespace Enshrouded_Server_Manager.Model;
public class DiscordProfile
{
    public bool Enabled { get; set; }
    public bool EmbedEnabled { get; set; }
    public bool StartEnabled { get; set; }
    public bool StopEnabled { get; set; }
    public bool UpdatingEnabled { get; set; }
    public bool BackupEnabled { get; set; }
    public bool BackupRestoreEnabled { get; set; }
    public bool RestartEnabled { get; set; }

    public bool LongResetEnabled { get; set; }
    public bool MediumResetEnabled { get; set; }
    public bool ShortResetEnabled { get; set; }
    public bool SoonResetEnabled { get; set; }
    public bool ImminentResetEnabled { get; set; }

    public string DiscordUrl { get; set; }

    public string ServerStartedMsg { get; set; }
    public string ServerStoppedMsg { get; set; }
    public string ServerUpdatingMsg { get; set; }
    public string BackupMsg { get; set; }
    public string BackupRestoreMsg { get; set; }
    public string RestartMsg { get; set; }
}

