using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;
class ServerStartedMessage : IApplicationEvent
{
    public ServerStartedMessage(ServerProfile profile)
    {
        ServerProfile = profile;
    }

    public ServerProfile ServerProfile { get; private set; }
}

