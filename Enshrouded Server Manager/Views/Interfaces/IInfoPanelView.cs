namespace Enshrouded_Server_Manager.Views;

public interface IInfoPanelView
{
    event EventHandler GithubLinkClicked;

    bool IsNewVersionAvailable { get; set; }
}