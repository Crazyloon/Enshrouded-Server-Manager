namespace Enshrouded_Server_Manager.Services.Interfaces;
public interface IMessageBox
{
    void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
}
