using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class MainFormPresenter
{
    IMainFormView _mainFormView;
    IVersionManagementService _versionManagementService;

    public MainFormPresenter(IMainFormView mainFormView,
        IVersionManagementService versionManagementService)
    {
        _mainFormView = mainFormView;
        _versionManagementService = versionManagementService;

        _mainFormView.ViewCreditsButtonClicked += (s, e) => OnViewCreditsButtonClicked();

        BeginApplicationVersionCheckTimer();
    }

    private void OnViewCreditsButtonClicked()
    {
        _mainFormView.ToggleCredits();
    }

    private void BeginApplicationVersionCheckTimer()
    {
        _versionManagementService.ManagerUpdate(_mainFormView.CurrentVersionText);
    }
}
