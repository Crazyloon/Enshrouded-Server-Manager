using Enshrouded_Server_Manager.Commands;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly IAdminPanelView _adminPanelView;
    private readonly ISteamCMDInstaller _steamCMDInstaller;
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IServer _server;

    public AdminPanelPresenter(
        ISteamCMDInstaller steamCMDInstaller,
        IFileSystemManager fileSystemManager,
        IServer server,
        IAdminPanelCommand[] commands,
        IAdminPanelView adminPanelView)
    {
        _adminPanelView = adminPanelView;
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemManager = fileSystemManager;
        _server = server;

        adminPanelView.SetCommands(commands);

        EventAggregator.Instance.Subscribe<ProfileSelectedMessage>(p => OnProfileSelected(p.SelectedProfile));
    }

    private void OnProfileSelected(ServerProfile selectedProfile)
    {
        //RefreshServerButtonsVisibility(serverSelectedText);
        //LoadServerSettings(serverSelectedText);
        //_versionManager.ServerUpdateCheck(serverSelectedText, btnUpdateServer);
    }
}
