namespace Enshrouded_Server_Manager.Views;
public partial class CreditsPanelWideView : UserControl, ICreditsPanelView
{
    public CreditsPanelWideView()
    {
        InitializeComponent();
    }

    public event EventHandler SupportLinkClicked
    {
        add => lnkGitHubSponsor.Click += value;
        remove => lnkGitHubSponsor.Click -= value;
    }
}
