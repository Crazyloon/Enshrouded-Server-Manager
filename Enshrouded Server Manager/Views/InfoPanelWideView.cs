using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class InfoPanelWideView : UserControl, IInfoPanelView, ICreditsPanelView
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

    public event EventHandler SupportLinkClicked
    {
        add => lblSupportLink.Click += value;
        remove => lblSupportLink.Click -= value;
    }
}
