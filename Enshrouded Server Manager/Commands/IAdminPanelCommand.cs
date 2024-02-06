using System.ComponentModel;

namespace Enshrouded_Server_Manager.Commands;
public interface IAdminPanelCommand : INotifyPropertyChanged
{
    void Execute();
    bool IsEnabled { get; set; }
    bool IsVisible { get; set; }
    Color BorderColor { get; set; }
}
