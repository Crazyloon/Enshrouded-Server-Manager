using Enshrouded_Server_Manager.Services;

namespace Enshrouded_Server_Manager.Commands;
public class InstallSteamCmd : CommandBase
{
    private readonly ISteamCMDInstaller _steamCMDInstaller;

    public InstallSteamCmd(ISteamCMDInstaller steamCMDInstaller)
    {
        _steamCMDInstaller = steamCMDInstaller;
    }

    public override void Execute()
    {
        _steamCMDInstaller.Install();


    }
}
