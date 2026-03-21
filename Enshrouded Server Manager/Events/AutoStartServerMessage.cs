using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;

public class AutoStartServerMessage : IApplicationEvent
{
    public AutoStartServerMessage(ServerProfile profile)
    {
        ServerProfile = profile;
    }

    public ServerProfile ServerProfile { get; private set; }
}
