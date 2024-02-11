namespace Enshrouded_Server_Manager.Events;
internal class AutoBackupSuccessMessage : IApplicationEvent
{
    public string ProfileName { get; }

    public AutoBackupSuccessMessage(string profileName)
    {
        ProfileName = profileName;
    }
}
