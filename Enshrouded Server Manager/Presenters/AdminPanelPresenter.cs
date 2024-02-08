using Enshrouded_Server_Manager.Commands;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class AdminPanelPresenter
{
    private readonly AdminPanelView _adminPanelView;
    private readonly ISteamCMDInstaller _steamCMDInstaller;
    private readonly IFileSystemManager _fileSystemManager;
    private readonly IServer _server;

    private AdminPanelModel _model;

    public AdminPanelPresenter(
        ISteamCMDInstaller steamCMDInstaller,
        IFileSystemManager fileSystemManager,
        IServer server,
        IAdminPanelCommand[] commands,
        AdminPanelView adminPanelView)
    {
        _adminPanelView = adminPanelView;
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemManager = fileSystemManager;
        _server = server;

        adminPanelView.SetCommands(commands);
    }
}
