using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class InfoPanelPresenter
{
    private readonly IInfoPanelView _infoPanelView;
    private readonly IVersionManagementService _versionManagementService;

    public InfoPanelPresenter(IInfoPanelView view,
        IVersionManagementService versionManagementService)
    {
        _infoPanelView = view;
        _versionManagementService = versionManagementService;


        EventAggregator.Instance.Subscribe<NewVersionAvailableMessage>(n => OnNewVersionAvailable());
    }

    private void OnNewVersionAvailable()
    {
        _infoPanelView.IsNewVersionAvailable = true;
    }
}
