using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class InfoPanelWideView : UserControl, IInfoPanelView
{
    public InfoPanelWideView()
    {
        InitializeComponent();
    }
    public bool IsNewVersionAvailable { get; set; }

    public event EventHandler GithubLinkClicked
    {
        add => lblGitHubLink.Click += value;
        remove => lblGitHubLink.Click -= value;
    }
}
