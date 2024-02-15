namespace Enshrouded_Server_Manager.Services;
public class MessageBoxService : IMessageBoxService
{
    public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        return MessageBox.Show(text, caption, buttons, icon);
    }
}
