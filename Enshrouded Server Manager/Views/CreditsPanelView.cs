namespace Enshrouded_Server_Manager.Views;
public partial class CreditsPanelView : UserControl, ICreditsPanelView
{
    public CreditsPanelView()
    {
        InitializeComponent();
    }

    public event EventHandler SupportLinkClicked
    {
        add => lnkGitHubSponsor.Click += value;
        remove => lnkGitHubSponsor.Click -= value;
    }
}
