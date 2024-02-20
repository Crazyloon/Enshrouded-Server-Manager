using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;
public class ServerResetTimerUpdatedMessage : IApplicationEvent
{
    public ServerResetTimerUpdatedMessage(ServerProfile profile, string timeLeft)
    {
        ServerProfile = profile;
        TimeLeft = timeLeft;
    }

    public ServerProfile ServerProfile { get; private set; }
    public string TimeLeft { get; private set; }
}
