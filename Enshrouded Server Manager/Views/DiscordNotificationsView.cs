using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class DiscordNotificationsView : UserControl, IDiscordNotificationsView
{
    public DiscordNotificationsView()
    {
        InitializeComponent();

        EventAggregator.Instance.Subscribe<DiscordSettingsSavedMessage>(m => OnDiscordSettingsSaved());
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

    public event EventHandler Load
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

    public string WebhookUrl
    {
        get => txtDiscordWebhookUrl.Text;
        set => txtDiscordWebhookUrl.Text = value;
    }

    private void OnDiscordSettingsSaved()
    {
        Interactions.AnimateSaveChangesButton(btnSaveDiscordSettings, btnSaveDiscordSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveDiscordSettings_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }
}
