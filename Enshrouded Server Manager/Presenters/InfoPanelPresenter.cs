using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class InfoPanelPresenter
{
    private readonly IInfoPanelView _infoPanelView;
    private readonly ISystemProcessService _systemProcess;

    public InfoPanelPresenter(IInfoPanelView view,
        ISystemProcessService systemProcess)
    {
        _infoPanelView = view;
        _systemProcess = systemProcess;

        _infoPanelView.GithubLinkClicked += (s, e) => OnGithubLinkClicked();
        EventAggregator.Instance.Subscribe<NewVersionAvailableMessage>(n => OnNewVersionAvailable());
    }

    private void OnGithubLinkClicked()
    {
        _systemProcess.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Urls.ESM_GITHUB_LINK);
    }

    private void OnNewVersionAvailable()
    {
        _infoPanelView.IsNewVersionAvailable = true;
    }
}
