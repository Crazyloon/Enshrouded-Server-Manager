using Enshrouded_Server_Manager.Commands;

namespace Enshrouded_Server_Manager.Views.Interfaces;
public interface IAdminPanelView
{
    void SetCommands(IAdminPanelCommand[] commands);
}
