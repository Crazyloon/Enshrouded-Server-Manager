using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services;

namespace Enshrouded_Server_Manager.Commands;
public class InstallSteamCmdCommand : CommandBase
{
    private readonly ISteamCMDInstaller _steamCMDInstaller;
    private readonly IFileSystemManager _fileSystemManager;

    public InstallSteamCmdCommand(ISteamCMDInstaller steamCMDInstaller, IFileSystemManager fileSystemManager)
    {
        _steamCMDInstaller = steamCMDInstaller;
        _fileSystemManager = fileSystemManager;

        EventAggregator.Instance.Subscribe<SteamCmdInstalledMessage>(b => IsEnabled = false);
    }

    public override void Execute()
    {
        _steamCMDInstaller.Install();

        EventAggregator.Instance.Publish(new SteamCmdInstalledMessage(_fileSystemManager.FileExists(Constants.ProcessNames.STEAM_CMD_EXE)));

        _steamCMDInstaller.Start();
    }
}
