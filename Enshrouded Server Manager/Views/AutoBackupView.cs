using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class AutoBackupView : UserControl, IAutoBackupView
{
    public AutoBackupView()
    {
        InitializeComponent();
    }

    public string BackupStats
    {
        get => lblProfileBackupsStats.Text;
        set => lblProfileBackupsStats.Text = value;
    }

    public bool IsAutoBackupEnabled
    {
        get => chkEnableBackups.Checked;
        set => chkEnableBackups.Checked = value;
    }

    public bool IsAutoBackupStatsVisible
    {
        get => lblProfileBackupsStats.Visible;
        set => lblProfileBackupsStats.Visible = value;
    }

    public int BackupInterval
    {
        get => (int)nudBackupInterval.Value;
        set => nudBackupInterval.Value = value;
    }

    public int MaxAutoBackupCount
    {
        get => (int)nudBackupMaxCount.Value;
        set => nudBackupMaxCount.Value = value;
    }

    public event EventHandler SaveAutoBackupSettingsClicked
    {
        add => btnSaveAutoBackup.Click += value;
        remove => btnSaveAutoBackup.Click -= value;
    }

    public event EventHandler EnableAutoBackupChanged
    {
        add => chkEnableBackups.CheckedChanged += value;
        remove => chkEnableBackups.CheckedChanged -= value;
    }

    public ServerProfile? SelectedProfile { get; set; }


    public void UpdateBackupInfo(string profileName, int backupCount, long diskConsumption)
    {
        if (lblProfileBackupsStats.InvokeRequired)
        {
            lblProfileBackupsStats.BeginInvoke(() =>
            {
                if (this.SelectedProfile is null || this.SelectedProfile.Name != profileName)
                {
                    return;
                }

                Interactions.UpdateBackupInfo(lblProfileBackupsStats, backupCount, diskConsumption);
            });
        }
        else
        {
            Interactions.UpdateBackupInfo(lblProfileBackupsStats, backupCount, diskConsumption);
        }

    }

    public void OnAutoBackupSuccess()
    {
        Interactions.AnimateSaveChangesButton(btnSaveAutoBackup, btnSaveAutoBackup.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveAutoBackup_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }
}
