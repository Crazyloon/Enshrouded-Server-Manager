using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views.Interfaces;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Enshrouded_Server_Manager.UnitTests;

[TestClass]
public class AdminPanelPresenterTests
{
    private ISteamCMDInstallerService _steamCMDInstaller;
    private IFileSystemService _fileSystemManager;
    private IVersionManagementService _versionManager;
    private ISystemProcessService _systemProcess;
    private IServerSettingsService _serverSettings;
    private IEnshroudedServerService _server;
    private IProfileService _profileService;
    private IDiscordService _discordService;
    private IAdminPanelView _adminPanel;

    public AdminPanelPresenterTests()
    {
        _steamCMDInstaller = Substitute.For<ISteamCMDInstallerService>();
        _fileSystemManager = Substitute.For<IFileSystemService>();
        _versionManager = Substitute.For<IVersionManagementService>();
        _systemProcess = Substitute.For<ISystemProcessService>();
        _serverSettings = Substitute.For<IServerSettingsService>();
        _server = Substitute.For<IEnshroudedServerService>();
        _profileService = Substitute.For<IProfileService>();
        _discordService = Substitute.For<IDiscordService>();
        _adminPanel = Substitute.For<IAdminPanelView>();
    }

    [TestMethod]
    public void ClickingOn_InstallSteamCMD_Should_InstallSteamCMD_Success()
    {
        //// Arrange
        bool expectedVisibility = true;

        _adminPanel.StartServerButtonState = new AdminButtonState()
        {
            Visible = false
        };
        _adminPanel.InstallServerButtonState = new AdminButtonState()
        {
            Visible = false
        };

        _fileSystemManager.FileExists(Arg.Any<string>()).Returns(true);


        _ = new AdminPanelPresenter(_steamCMDInstaller, _fileSystemManager, _versionManager, _systemProcess, _serverSettings, _server, _profileService, _discordService, _adminPanel);

        //// Act
        _adminPanel.InstallSteamCMDButtonClicked += Raise.Event();

        //// Assert
        _steamCMDInstaller.Received().Install();
        _adminPanel.StartServerButtonState.Visible.Should().Be(expectedVisibility);
        _adminPanel.InstallServerButtonState.Visible.Should().Be(expectedVisibility);
        _steamCMDInstaller.Received().Start();

    }
}