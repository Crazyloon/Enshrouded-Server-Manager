using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class CreditsPanelPresenter
{
    private readonly ICreditsPanelView _view;
    private readonly ISystemProcessService _systemProcessService;

    public CreditsPanelPresenter(ICreditsPanelView view,
        ISystemProcessService systemProcessService)
    {
        _view = view;
        _systemProcessService = systemProcessService;

        _view.SupportLinkClicked += (sender, args) => OnSupportLinkClicked();
    }

    private void OnSupportLinkClicked()
    {
        _systemProcessService.Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Urls.GITHUB_SPONSOR_LINK);
    }
}
