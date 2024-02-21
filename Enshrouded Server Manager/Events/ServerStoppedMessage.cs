using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;
class ServerStoppedMessage : IApplicationEvent
{
    public ServerStoppedMessage(ServerProfile profile)
    {
        ServerProfile = profile;
    }

    public ServerProfile ServerProfile { get; private set; }
}

