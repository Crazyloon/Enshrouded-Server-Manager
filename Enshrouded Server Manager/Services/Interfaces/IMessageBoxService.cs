namespace Enshrouded_Server_Manager.Services;
public interface IMessageBoxService
{
    DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
}
