using Enshrouded_Server_Manager.Enums;

namespace Enshrouded_Server_Manager.Events;
public class NavigationChangedMessage : IApplicationEvent
{
    public NavigationChangedMessage(ViewSelection viewSelection)
    {
        ViewSelection = viewSelection;
    }

    public ViewSelection ViewSelection { get; private set; }
}
