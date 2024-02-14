using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;
public interface IRestoreBackupView
{
    event EventHandler RestoreSelectedFileClicked;
    event EventHandler SelectFileToRestoreClicked;
    event CancelEventHandler FileToRestoreSelected;

    string RestoreFilePath { get; set; }
    OpenFileDialog FileDialog { get; }
    void AnimateSaveButton();
}
