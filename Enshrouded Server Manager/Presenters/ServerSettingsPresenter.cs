using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;

namespace Enshrouded_Server_Manager.Presenters;
public class ServerSettingsPresenter
{
    private readonly IServerSettingsView _serverSettingsView;
    private readonly IServerSettingsService _serverSettingsService;

    public ServerSettingsPresenter(IServerSettingsView serverSettingsView, IServerSettingsService serverSettingsService)
    {
        _serverSettingsView = serverSettingsView;
        _serverSettingsService = serverSettingsService;

        _serverSettingsView.ShowPasswordButtonClicked += (sender, e) => TogglePasswordVisiblity();

        EventAggregator.Instance.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
    }

    public void SetServerSettings(ServerSettings serverSettings)
    {
        _serverSettingsView.ServerName = serverSettings.Name;
        _serverSettingsView.Password = serverSettings.Password;
        _serverSettingsView.IpAddress = serverSettings.Ip;
        _serverSettingsView.GamePort = serverSettings.GamePort;
        _serverSettingsView.QueryPort = serverSettings.QueryPort;
        _serverSettingsView.MaxPlayers = serverSettings.SlotCount;
    }

    private void OnServerProfileSelected(ServerProfile serverProfile)
    {
        var settings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
        SetServerSettings(settings);
    }

    public void TogglePasswordVisiblity()
    {
        var text = _serverSettingsView.ShowPasswordButtonText;
        // \0 is a null character, which is used to show the password
        // * is the character displayed instead of each character in the password
        _serverSettingsView.PasswordChar = text == Constants.ButtonText.SHOW_PASSWORD ? '\0' : '*';

        _serverSettingsView.ShowPasswordButtonText = text == Constants.ButtonText.SHOW_PASSWORD ? Constants.ButtonText.HIDE_PASSWORD : Constants.ButtonText.SHOW_PASSWORD;
    }
}
