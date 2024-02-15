namespace Enshrouded_Server_Manager.Events;
internal class AutoBackupSavedSuccessMessage : IApplicationEvent
{
    public string ProfileName { get; }

    public AutoBackupSavedSuccessMessage(string profileName)
    {
        ProfileName = profileName;
    }
}
