namespace Enshrouded_Server_Manager.Services;
public interface IMessageBoxService
{
    void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
}
