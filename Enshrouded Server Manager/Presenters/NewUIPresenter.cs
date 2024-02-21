using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;

namespace Enshrouded_Server_Manager.Presenters;
public class NewUIPresenter
{
    INewUIFormView _newUIFormView;
    IVersionManagementService _versionManagementService;

    public NewUIPresenter(INewUIFormView newFormView,
        IVersionManagementService versionManagement)
    {
        _newUIFormView = newFormView;
        _versionManagementService = versionManagement;
    }
}
