using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;

public interface IAutoBackupView
{
    event EventHandler SaveAutoBackupSettingsClicked;
    event EventHandler SelectedProfileChanged;
    event EventHandler EnableAutoBackupChanged;

    string BackupStats { get; set; }
    bool IsAutoBackupEnabled { get; set; }
    bool IsAutoBackupStatsVisible { get; set; }
    int BackupInterval { get; set; }
    int MaxAutoBackupCount { get; set; }

    ServerProfile? SelectedProfile { get; }
    void SetProfiles(BindingList<ServerProfile> profiles);
    void UpdateBackupInfo(string profileName, int backupCount, long diskConsumption);
}