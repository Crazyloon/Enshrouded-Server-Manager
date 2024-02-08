using Enshrouded_Server_Manager.Services.Interfaces;

namespace Enshrouded_Server_Manager.Services;
public class MessageBoxService : IMessageBoxService
{
    public void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        MessageBox.Show(text, caption, buttons, icon);
    }
}
