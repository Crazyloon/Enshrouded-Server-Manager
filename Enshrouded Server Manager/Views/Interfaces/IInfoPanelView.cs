namespace Enshrouded_Server_Manager.Views;

public interface IInfoPanelView
{
    event EventHandler GithubLinkClicked;
    event EventHandler SupportLinkClicked;

    bool IsNewVersionAvailable { get; set; }
}