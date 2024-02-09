namespace Enshrouded_Server_Manager.Views.Interfaces;
public interface IAdminPanelView
{
    event EventHandler InstallSteamCMDButtonClicked;
    event EventHandler WindowsFirewallButtonClicked;
    event EventHandler StartServerButtonClicked;
    event EventHandler StopServerButtonClicked;
    event EventHandler InstallServerButtonClicked;
    event EventHandler UpdateServerButtonClicked;
    event EventHandler SaveBackupButtonClicked;
    event EventHandler OpenBackupFolderButtonClicked;
    event EventHandler OpenSavegameFolderButtonClicked;
    event EventHandler OpenLogFolderButtonClicked;

    bool InstallSteamCMDButtonEnabled { get; set; }
    bool InstallSteamCMDButtonVisible { get; set; }

    bool WindowsFirewallButtonEnabled { get; set; }
    bool WindowsFirewallButtonVisible { get; set; }

    bool StartServerButtonEnabled { get; set; }
    bool StartServerButtonVisible { get; set; }

    bool StopServerButtonVisible { get; set; }
    bool StopServerButtonEnabled { get; set; }

    bool InstallServerButtonVisible { get; set; }
    bool InstallServerButtonEnabled { get; set; }

    bool UpdateServerButtonVisible { get; set; }
    bool UpdateServerButtonEnabled { get; set; }
    Color UpdateServerButtonBorderColor { get; set; }

    bool SaveBackupButtonVisible { get; set; }
    bool SaveBackupButtonEnabled { get; set; }

    bool OpenBackupFolderButtonVisible { get; set; }
    bool OpenBackupFolderButtonEnabled { get; set; }

    bool OpenSavegameFolderButtonVisible { get; set; }
    bool OpenSavegameFolderButtonEnabled { get; set; }

    bool OpenLogFolderButtonVisible { get; set; }
    bool OpenLogFolderButtonEnabled { get; set; }
}
