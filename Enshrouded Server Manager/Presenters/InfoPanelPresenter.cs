using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class InfoPanelPresenter
{
    private readonly IInfoPanelView _infoPanelView;
    private readonly IEventAggregator _eventAggregator;
    private readonly ISystemProcessService _systemProcess;

    public InfoPanelPresenter(IInfoPanelView view,
        IEventAggregator eventAggregator,
        ISystemProcessService systemProcess)
    {
        _infoPanelView = view;
        _eventAggregator = eventAggregator;
        _systemProcess = systemProcess;

        _infoPanelView.GithubLinkClicked += (s, e) => OnGithubLinkClicked();
        _eventAggregator.Subscribe<NewVersionAvailableMessage>(n => OnNewVersionAvailable());
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
