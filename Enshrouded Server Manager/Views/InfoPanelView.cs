using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager;
public partial class InfoPanelView : UserControl, IInfoPanelView
{
    public InfoPanelView()
    {
        InitializeComponent();
    }

    public event EventHandler GithubLinkClicked
    {
        add => lblGitHubLink.Click += value;
        remove => lblGitHubLink.Click -= value;
    }

    public bool IsNewVersionAvailable
    {
        get => lblNewVersionAvailableNotification.Visible;
        set => lblNewVersionAvailableNotification.Visible = value;
    }
}
