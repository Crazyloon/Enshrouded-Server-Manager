using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly IAdminPanelView _adminPanelView;
    private readonly ISteamCMDInstaller _steamCMDInstaller;
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IServer _server;

    private AdminPanelModel _model;

    public AdminPanelPresenter(
        IAdminPanelView adminPanelView,
        ISteamCMDInstaller steamCMDInstaller,
        IFileSystemManager fileSystemManager,
        IServer server,
        AdminPanelModel model)
    {
        _adminPanelView = adminPanelView;
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemManager = fileSystemManager;
        _server = server;
        _model = model;

        EventAggregator.Instance.Subscribe<SteamCmdInstalledMessage>(b => OnSteamCmdInstallVerified(b.IsInstalled));
    }

    public void OpenBackupFolder_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void SaveBackup_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void InstallServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void UpdateServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void StopServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void StartServer_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void OpenWindowsFirewall_ButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void InstallSteamCmd_ButtonClicked(object sender, EventArgs e)
    {
        _steamCMDInstaller.Install();

        EventAggregator.Instance.Publish(new SteamCmdInstalledMessage(_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE)));

        _steamCMDInstaller.Start();
    }

    private void OnSteamCmdInstallVerified(bool isInstalled)
    {
        if (isInstalled)
        {
            //_adminPanelView.btnInstallServer.Visible = true;
            //_adminPanelView.btnStartServer.Visible = true;
        }
    }

    //public void RefreshAllServerButtonsVisiblity(string selectedProfileName)
    //{
    //    var gameServerExe = Path.Join(Constants.Paths.SERVER_PATH, selectedProfileName, Constants.Files.GAME_SERVER_EXE);

    //    _adminPanelView.btnStopServer.Visible = false;
    //    if (_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
    //    {
    //        _adminPanelView.btnInstallServer.Visible = true;
    //        _adminPanelView.btnStartServer.Visible = true;
    //    }

    //    if (_fileSystemManager.FileExists(gameServerExe))
    //    {
    //        _adminPanelView.btnInstallServer.Visible = false;
    //        _adminPanelView.btnUpdateServer.Visible = true;
    //    }
    //    else
    //    {
    //        _adminPanelView.btnInstallServer.Visible = true;
    //        _adminPanelView.btnUpdateServer.Visible = false;
    //    }

    //    if (!_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE))
    //    {
    //        _adminPanelView.btnInstallServer.Visible = false;
    //        _adminPanelView.btnStartServer.Visible = false;
    //    }

    //    try
    //    {
    //        if (_server.IsRunning(selectedProfileName))
    //        {
    //            _adminPanelView.btnStartServer.Visible = false;
    //            _adminPanelView.btnStopServer.Visible = true;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        var pidJsonFile = Path.Join(Constants.Paths.CACHE_DIRECTORY, selectedProfileName, Constants.Files.PID_JSON);

    //        if (_fileSystemManager.FileExists(pidJsonFile))
    //        {
    //            _fileSystemManager.DeleteFile(pidJsonFile);
    //        }
    //    }
    //}
}
