using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services.Interfaces;
using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager.Presenters;
public class ProfileSelectorPresenter
{
    private readonly IProfileSelectorView _profileSelectorView;
    private readonly IProfileManager _profileManager;
    private readonly IFileSystemManager _fileSystemManager;

    private List<ServerProfile>? _profiles;

    public ProfileSelectorPresenter(IProfileSelectorView profileSelectorView, IProfileManager profileManager, IFileSystemManager fileSystemManager, List<ServerProfile>? serverProfiles)
    {
        _profileSelectorView = profileSelectorView;
        _profileManager = profileManager;
        _fileSystemManager = fileSystemManager;
        _profiles = serverProfiles;

        profileSelectorView.SelectedProfileChanged += OnSelectedProfileChanged;
        LoadProfiles(_profiles);
    }

    private void OnSelectedProfileChanged(object? sender, EventArgs e)
    {
        EventAggregator.Instance.Publish(new ProfileSelectedMessage(_profileSelectorView.SelectedProfile));
    }

    public void LoadProfiles(List<ServerProfile>? profiles)
    {
        if (profiles is not null && profiles.Any())
        {
            _profiles = profiles;
        }
        else
        {
            _profiles = _profileManager.LoadServerProfiles(JsonSettings.Default);
        }

        if (_profiles is not null && _profiles.Any())
        {
            _profileSelectorView.SetProfiles(_profiles);
        }
    }
}
