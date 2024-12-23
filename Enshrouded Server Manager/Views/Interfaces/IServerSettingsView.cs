namespace Enshrouded_Server_Manager.Views;

public interface IServerSettingsView
{
    string ServerName { get; set; }
    string IpAddress { get; set; }
    int GamePort { get; set; }
    int QueryPort { get; set; }
    int MaxPlayers { get; set; }

    event EventHandler SaveChangesButtonClicked;

    public void AnimateSaveButton();
}