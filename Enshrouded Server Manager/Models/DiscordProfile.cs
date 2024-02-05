﻿using System.Web;

namespace Enshrouded_Server_Manager.Model;
public class DiscordProfile
{
    public string DiscordUrl { get; set; }
    public bool Enabled { get; set; }
    public bool StartEnabled { get; set; }
    public bool StopEnabled { get; set; }
    public bool UpdatingEnabled { get; set; }
    public bool BackupEnabled { get; set; }
    public bool EmbedEnabled { get; set; }
}

