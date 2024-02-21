using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class DiscordNotificationsView : UserControl, IDiscordNotificationsView
{
    public DiscordNotificationsView()
    {
        InitializeComponent();
    }

    public event EventHandler SaveDiscordNotificationsSettingsClicked
    {
        add => btnSaveDiscordSettings.Click += value;
        remove => btnSaveDiscordSettings.Click -= value;
    }

    public event EventHandler TestDiscordMessageClicked
    {
        add => btnTestDiscord.Click += value;
        remove => btnTestDiscord.Click -= value;
    }

    public event EventHandler DiscordSettingsLoad
    {
        add => Load += value;
        remove => Load -= value;
    }

    public bool IsDiscordNotificationsEnabled
    {
        get => chkEnableDiscord.Checked;
        set => chkEnableDiscord.Checked = value;
    }

    public bool IsEmbedsEnabled
    {
        get => chkEmbed.Checked;
        set => chkEmbed.Checked = value;
    }

    public bool IsNotifyOnStartEnabled
    {
        get => chkNotifiServerStarted.Checked;
        set => chkNotifiServerStarted.Checked = value;
    }

    public bool IsNotifyOnStopEnabled
    {
        get => chkNotifiServerStopped.Checked;
        set => chkNotifiServerStopped.Checked = value;
    }

    public bool IsNotifyOnUpdateEnabled
    {
        get => chkNotifiServerUpdating.Checked;
        set => chkNotifiServerUpdating.Checked = value;
    }

    public bool IsNotifyOnBackupEnabled
    {
        get => chkNotifiBackup.Checked;
        set => chkNotifiBackup.Checked = value;
    }

    public bool IsNotifyOnBackupRestoreEnabled
    {
        get => chkNotifiBackupRestore.Checked;
        set => chkNotifiBackupRestore.Checked = value;
    }

    public bool IsNotifyOnServerRestartEnabled
    {
        get => chkNotifyRestart.Checked;
        set => chkNotifyRestart.Checked = value;
    }

    public bool IsLongResetMessageEnabled
    {
        get => chkLong.Checked;
        set => chkLong.Checked = value;
    }

    public bool IsMediumResetMessageEnabled
    {
        get => chkMed.Checked;
        set => chkMed.Checked = value;
    }

    public bool IsShortResetMessageEnabled
    {
        get => chkShort.Checked;
        set => chkShort.Checked = value;
    }

    public bool IsSoonResetMessageEnabled
    {
        get => chkSoon.Checked;
        set => chkSoon.Checked = value;
    }

    public bool IsImminentResetMessageEnabled
    {
        get => chkImminent.Checked;
        set => chkImminent.Checked = value;
    }

    public string ServerStartedMessage
    {
        get => txtServerOnlineMsg.Text;
        set => txtServerOnlineMsg.Text = value;
    }

    public string ServerStoppedMessage
    {
        get => txtServerStoppedMsg.Text;
        set => txtServerStoppedMsg.Text = value;
    }

    public string ServerUpdatingMessage
    {
        get => txtServerUpdatingMsg.Text;
        set => txtServerUpdatingMsg.Text = value;
    }

    public string BackupCreatedMessage
    {
        get => txtBackupMsg.Text;
        set => txtBackupMsg.Text = value;
    }

    public string BackupRestoredMessage
    {
        get => txtBackupRestoreMsg.Text;
        set => txtBackupRestoreMsg.Text = value;
    }

    public string ServerRestartMessage
    {
        get => txtRestartMsg.Text;
        set => txtRestartMsg.Text = value;
    }

    public string WebhookUrl
    {
        get => txtDiscordWebhookUrl.Text;
        set => txtDiscordWebhookUrl.Text = value;
    }

    public void AnimateSaveButton()
    {
        Interactions.AnimateSaveChangesButton(btnSaveDiscordSettings, btnSaveDiscordSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveDiscordSettings_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }
}
