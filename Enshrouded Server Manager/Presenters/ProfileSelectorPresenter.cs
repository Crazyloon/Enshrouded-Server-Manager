using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Helpers;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class ProfileSelectorPresenter
{
    private readonly IProfileSelectorView _profileSelectorView;
    private readonly IProfileService _profileManager;
    private readonly IFileSystemService _fileSystemService;

    private BindingList<ServerProfile>? _profiles;

    public ProfileSelectorPresenter(IProfileSelectorView profileSelectorView, IProfileService profileManager, IFileSystemService fileSystemManager, BindingList<ServerProfile>? serverProfiles)
    {
        _profileSelectorView = profileSelectorView;
        _profileManager = profileManager;
        _fileSystemService = fileSystemManager;
        _profiles = serverProfiles;

        profileSelectorView.SelectedProfileChanged += OnSelectedProfileChanged;
        LoadProfiles(_profiles);
    }

    private void OnSelectedProfileChanged(object? sender, EventArgs e)
    {
        EventAggregator.Instance.Publish(new ProfileSelectedMessage(_profileSelectorView.SelectedProfile));
    }

    private void LoadProfiles(BindingList<ServerProfile>? profiles)
    {
        if (profiles is not null && profiles.Any())
        {
            _profiles = profiles;
        }
        else
        {
            _profiles = new BindingList<ServerProfile>(_profileManager.LoadServerProfiles(JsonSettings.Default));
        }

        if (_profiles is not null && _profiles.Any())
        {
            _profileSelectorView.SetProfiles(_profiles);
        }
    }
}
