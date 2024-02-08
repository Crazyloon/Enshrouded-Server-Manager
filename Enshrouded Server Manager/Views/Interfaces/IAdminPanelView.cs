using Enshrouded_Server_Manager.Models;

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

    AdminButtonState InstallSteamCMDButtonState { get; set; }
    AdminButtonState WindowsFirewallButtonState { get; set; }
    AdminButtonState StartServerButtonState { get; set; }
    AdminButtonState StopServerButtonState { get; set; }
    AdminButtonState InstallServerButtonState { get; set; }
    AdminButtonState UpdateServerButtonState { get; set; }
    AdminButtonState SaveBackupButtonState { get; set; }
    AdminButtonState OpenBackupFolderButtonState { get; set; }
    AdminButtonState OpenSavegameFolderButtonState { get; set; }
    AdminButtonState OpenLogFolderButtonState { get; set; }
}
