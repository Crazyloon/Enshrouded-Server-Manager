namespace Enshrouded_Server_Manager;

public interface IServerSettingsView
{
    string ServerName { get; set; }
    string Password { get; set; }
    string IpAddress { get; set; }
    int GamePort { get; set; }
    int QueryPort { get; set; }
    int MaxPlayers { get; set; }
    string ShowPasswordButtonText { get; set; }
    bool IsPasswordShown { get; set; }
    char PasswordChar { get; set; }

    event EventHandler ShowPasswordButtonClicked;
    event EventHandler SaveChangesButtonClicked;
}