using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly IAdminPanelView _adminPanelView;
    private readonly ISteamCMDInstaller _steamCMDInstaller;
    private AdminPanelModel _model;

    public AdminPanelPresenter(
        IAdminPanelView adminPanelView,
        ISteamCMDInstaller steamCMDInstaller)
    {
        _adminPanelView = adminPanelView;
        _steamCMDInstaller = steamCMDInstaller;
    }

    private void OpenBackupFolder_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SaveBackup_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void InstallServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UpdateServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void StopServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void StartServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OpenWindowsFirewall_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void InstallSteamCmd_ButtonClicked(object sender, EventArgs e)
    {
        _steamCMDInstaller.Install();
    }
}
