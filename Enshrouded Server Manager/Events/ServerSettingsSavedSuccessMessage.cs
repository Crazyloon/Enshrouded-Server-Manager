using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;
public class ServerSettingsSavedSuccessMessage : IApplicationEvent
{
    public ServerSettings ServerSettings { get; private set; }

    public ServerSettingsSavedSuccessMessage(ServerSettings serverSettings)
    {
        this.ServerSettings = serverSettings;
    }
}
