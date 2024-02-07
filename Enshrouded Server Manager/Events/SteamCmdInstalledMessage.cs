namespace Enshrouded_Server_Manager.Events;
public class SteamCmdInstalledMessage : IApplicationEvent
{
    public SteamCmdInstalledMessage(bool isInstalled)
    {
        IsInstalled = isInstalled;
    }

    public bool IsInstalled { get; private set; }
}
