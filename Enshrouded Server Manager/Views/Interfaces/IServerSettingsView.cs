using Enshrouded_Server_Manager.Enums;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;

public interface IServerSettingsView
{
    string ServerName { get; set; }
    string IpAddress { get; set; }
    int GamePort { get; set; }
    int QueryPort { get; set; }
    int MaxPlayers { get; set; }
    bool EnableVoiceChat { get; set; }
    bool EnableTextChat { get; set; }
    string GameSettingsPreset { get; set; }

    event EventHandler SaveChangesButtonClicked;
    event EventHandler cbxGameSettingsPresetChanged;

    void SetGameSettingsPreset(BindingList<GameSettingsPreset> gameSettingsPreset);

    public void AnimateSaveButton();
}