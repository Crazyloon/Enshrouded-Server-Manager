using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;
internal class AutoBackupSavedSuccessMessage : IApplicationEvent
{
    public ServerProfile Profile { get; }

    public AutoBackupSavedSuccessMessage(ServerProfile profile)
    {
        Profile = profile;
    }
}
