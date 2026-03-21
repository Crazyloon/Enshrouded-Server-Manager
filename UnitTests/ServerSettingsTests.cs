using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using NSubstitute;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.UnitTests;

[TestClass]
public class ServerSettingsTests
{
    private IServerSettingsView _serverSettingsView;
    private ISteamCMDInstallerService _steamCMDInstallerService;
    private IFileSystemService _fileSystemService;
    private IVersionManagementService _versionManagementService;
    private ISystemProcessService _systemProcessService;
    private IServerSettingsService _serverSettingsService;
    private IEnshroudedServerService _enshroudedServerService;
    private IProfileService _profileService;
    private IDiscordService _discordService;
    private IBackupService _backupService;
    private IEventAggregator _eventAggregator;
    private IFileLoggerService _logger;

    private ServerProfile _serverProfile;
    private ProfileSelectedMessage _profileSelectedMessage;
    private BindingList<ServerProfile> _profiles;
    private ServerSettings _serverSettings = new ServerSettings
    {
        Name = "TestServerName",
        Ip = "0.0.0.0",
        GamePort = 15636,
        QueryPort = 15637,
        SlotCount = 8,
        LogDirectory = "./logs",
        SaveDirectory = "./savegame"
    };


    public ServerSettingsTests()
    {
        // Setup: This runs before each test

        _serverSettingsView = Substitute.For<IServerSettingsView>();
        _steamCMDInstallerService = Substitute.For<ISteamCMDInstallerService>();
        _fileSystemService = Substitute.For<IFileSystemService>();
        _versionManagementService = Substitute.For<IVersionManagementService>();
        _systemProcessService = Substitute.For<ISystemProcessService>();
        _serverSettingsService = Substitute.For<IServerSettingsService>();
        _enshroudedServerService = Substitute.For<IEnshroudedServerService>();
        _profileService = Substitute.For<IProfileService>();
        _discordService = Substitute.For<IDiscordService>();
        _backupService = Substitute.For<IBackupService>();
        _eventAggregator = Substitute.For<IEventAggregator>();
        _logger = Substitute.For<IFileLoggerService>();

        // Setup for most tests requires a selected profile
        _serverProfile = new ServerProfile() { Name = "TestServer" };
        _profileSelectedMessage = new ProfileSelectedMessage(_serverProfile);
        _profiles = new BindingList<ServerProfile> { _serverProfile };
        _serverSettingsService.LoadServerSettings(Arg.Any<string>()).Returns(_serverSettings);
        _eventAggregator.Publish(_profileSelectedMessage);
    }

    [TestMethod]
    public void SetServerSettings_ShouldSetServerSettingsInView_Success()
    {
        // Arrange
        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);
        presenter.OnServerProfileSelected(_serverProfile);

        var serverSettings = new ServerSettings
        {
            Name = "TestServer",
            Ip = "0.0.0.0",
            GamePort = 15636,
            QueryPort = 15637,
            SlotCount = 8,
            LogDirectory = "./logs",
            SaveDirectory = "./savegame"
        };

        // Act
        presenter.SetServerSettings(serverSettings);

        // Assert
        Assert.AreEqual(_serverSettingsView.ServerName, serverSettings.Name);
        Assert.AreEqual(_serverSettingsView.IpAddress, serverSettings.Ip);
        Assert.AreEqual(_serverSettingsView.GamePort, serverSettings.GamePort);
        Assert.AreEqual(_serverSettingsView.QueryPort, serverSettings.QueryPort);
        Assert.AreEqual(_serverSettingsView.MaxPlayers, serverSettings.SlotCount);
    }

    [TestMethod]
    public void OnServerProfileSelected_ShouldLoadServerSettings_Success()
    {
        // Arrange
        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);

        // Act // Done in constructor
        presenter.OnServerProfileSelected(_serverProfile);

        // Assert
        _serverSettingsService.Received().LoadServerSettings(Arg.Is(_serverProfile.Name));
        Assert.AreEqual(_serverSettingsView.ServerName, _serverSettings.Name);
        Assert.AreEqual(_serverSettingsView.IpAddress, _serverSettings.Ip);
        Assert.AreEqual(_serverSettingsView.GamePort, _serverSettings.GamePort);
        Assert.AreEqual(_serverSettingsView.QueryPort, _serverSettings.QueryPort);
        Assert.AreEqual(_serverSettingsView.MaxPlayers, _serverSettings.SlotCount);
    }

    [TestMethod]
    public void OnServerProfileSelected_ShouldSetAutoStartServerInView_Success()
    {
        // Scenario: When a profile is selected, the auto-start checkbox should reflect the profile's AutoStartServer setting
        // Arrange
        _serverProfile.AutoStartServer = true;
        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);

        // Act
        presenter.OnServerProfileSelected(_serverProfile);

        // Assert
        Assert.AreEqual(_serverSettingsView.AutoStartServer, _serverProfile.AutoStartServer);
    }

    [TestMethod]
    public void ClickingOnSaveChangesButton_ShouldSaveServerSettings_Success()
    {
        // Scenario: The user has made changes to the server settings and clicked on the save button
        // Given the user has selected a profile and made changes to the server settings
        // And the server is not running
        // When the user clicks on the save button
        // Then the server settings should be saved

        // Arrange
        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);
        presenter.OnServerProfileSelected(_serverProfile);

        _serverSettingsService.SaveServerSettings(Arg.Any<ServerSettings>(), Arg.Any<ServerProfile>()).Returns(true);

        // Act
        _serverSettingsView.ServerName = "RealServer";
        _serverSettingsView.IpAddress = "0.0.0.0";
        _serverSettingsView.GamePort = 15636;
        _serverSettingsView.QueryPort = 15637;
        _serverSettingsView.MaxPlayers = 8;

        var savedSettings = new ServerSettings()
        {
            Name = _serverSettingsView.ServerName,
            SaveDirectory = Constants.Paths.ENSHROUDED_SAVE_GAME_DIRECTORY,
            LogDirectory = Constants.Paths.ENSHROUDED_LOGS_DIRECTORY,
            Ip = _serverSettingsView.IpAddress,
            GamePort = Convert.ToInt32($"{_serverSettingsView.GamePort}"),
            QueryPort = Convert.ToInt32($"{_serverSettingsView.QueryPort}"),
            SlotCount = Convert.ToInt32($"{_serverSettingsView.MaxPlayers}")
        };

        _serverSettingsView.SaveChangesButtonClicked += Raise.Event();

        // Assert
        _serverSettingsService.Received().SaveServerSettings(Arg.Is(savedSettings), Arg.Is(_serverProfile));
    }

    [TestMethod]
    public void ClickingOnSaveChangesButton_WhenServerIsRunning_ShouldShowErrorMessage_Success()
    {
        // Scenario: The user has made changes to the server settings and clicked on the save button
        // Given the user has made changes to the server settings
        // And the server is running
        // When the user clicks on the save button
        // Then an error message should be shown

        // Arrange
        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);
        presenter.OnServerProfileSelected(_serverProfile);

        _serverSettingsService.SaveServerSettings(Arg.Any<ServerSettings>(), Arg.Any<ServerProfile>()).Returns(true);

        // Act
        _serverSettingsView.SaveChangesButtonClicked += Raise.Event();

        // Assert
        _serverSettingsView.Received().AnimateSaveButton();
    }

    [TestMethod]
    public void SaveServerSettings_WithAutoStartEnabled_ShouldSetAutoStartOnlyForSelectedProfile_Success()
    {
        // Scenario: When a user enables auto-start for a profile, no other profile should have auto-start enabled
        // Arrange
        var otherProfile = new ServerProfile() { Name = "OtherServer", AutoStartServer = true };
        _profiles.Add(otherProfile);

        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);
        presenter.OnServerProfileSelected(_serverProfile);

        _serverSettingsService.SaveServerSettings(Arg.Any<ServerSettings>(), Arg.Any<ServerProfile>()).Returns(true);
        _serverSettingsView.AutoStartServer.Returns(true);

        // Act
        _serverSettingsView.SaveChangesButtonClicked += Raise.Event();

        // Assert
        Assert.IsTrue(_serverProfile.AutoStartServer);
        Assert.IsFalse(otherProfile.AutoStartServer);
    }

    [TestMethod]
    public void SaveServerSettings_WithAutoStartDisabled_ShouldNotDisableOtherProfiles_Success()
    {
        // Scenario: When a user disables auto-start for a profile, other profiles should remain unchanged
        // Arrange
        var otherProfile = new ServerProfile() { Name = "OtherServer", AutoStartServer = true };
        _profiles.Add(otherProfile);

        var presenter = new ServerSettingsPresenter(_serverSettingsView, _eventAggregator, _serverSettingsService, _fileSystemService, _enshroudedServerService, _logger, _profiles);
        presenter.OnServerProfileSelected(_serverProfile);

        _serverSettingsService.SaveServerSettings(Arg.Any<ServerSettings>(), Arg.Any<ServerProfile>()).Returns(true);
        _serverSettingsView.AutoStartServer.Returns(false);

        // Act
        _serverSettingsView.SaveChangesButtonClicked += Raise.Event();

        // Assert
        Assert.IsFalse(_serverProfile.AutoStartServer);
        Assert.IsTrue(otherProfile.AutoStartServer);
    }
}
