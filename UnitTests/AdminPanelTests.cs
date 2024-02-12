using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Presenters;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using System.Drawing;

namespace Enshrouded_Server_Manager.UnitTests;

[TestClass]
public class AdminPanelTests
{
    private ISteamCMDInstallerService _steamCMDInstallerService;
    private IFileSystemService _fileSystemService;
    private IVersionManagementService _versionManagementService;
    private ISystemProcessService _systemProcessService;
    private IServerSettingsService _serverSettingsService;
    private IEnshroudedServerService _enshroudedServerService;
    private IProfileService _profileService;
    private IDiscordService _discordService;
    private IBackupService _backupService;
    private IAdminPanelView _adminPanelView;
    private IEventAggregator _eventAggregator;

    private AdminPanelPresenter _presenter;
    private ServerProfile _serverProfileUnderTest;

    public AdminPanelTests()
    {
        // Setup: This runs before each test

        _steamCMDInstallerService = Substitute.For<ISteamCMDInstallerService>();
        _fileSystemService = Substitute.For<IFileSystemService>();
        _versionManagementService = Substitute.For<IVersionManagementService>();
        _systemProcessService = Substitute.For<ISystemProcessService>();
        _serverSettingsService = Substitute.For<IServerSettingsService>();
        _enshroudedServerService = Substitute.For<IEnshroudedServerService>();
        _profileService = Substitute.For<IProfileService>();
        _discordService = Substitute.For<IDiscordService>();
        _backupService = Substitute.For<IBackupService>();
        _adminPanelView = Substitute.For<IAdminPanelView>();
        _eventAggregator = Substitute.For<IEventAggregator>();

        _presenter = new AdminPanelPresenter(_adminPanelView, _steamCMDInstallerService, _fileSystemService, _versionManagementService, _systemProcessService, _serverSettingsService, _enshroudedServerService, _profileService, _discordService, _backupService);

        _serverProfileUnderTest = new ServerProfile() { Name = "TestServer" };
        EventAggregator.Instance.Publish(new ProfileSelectedMessage(_serverProfileUnderTest));
    }

    [TestMethod]
    public void ClickingOn_InstallSteamCMD_Should_Install_SteamCMD_Success()
    {
        // Scenario: User clicks on the Install SteamCMD button
        // Given the user has not installed SteamCMD
        // When the user clicks on the Install SteamCMD button
        // Then SteamCMD should be installed
        // And the Start Server button should be visible
        // And the Install Server button should be visible

        // Arrange
        bool expectedVisibility = true;

        _adminPanelView.StartServerButtonVisible = false;
        _adminPanelView.InstallServerButtonVisible = false;

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(true);

        // Act
        _adminPanelView.InstallSteamCMDButtonClicked += Raise.Event();

        // Assert
        _steamCMDInstallerService.Received().Install();
        _adminPanelView.StartServerButtonVisible.Should().Be(expectedVisibility);
        _adminPanelView.InstallServerButtonVisible.Should().Be(expectedVisibility);
        _steamCMDInstallerService.Received().Start();

    }

    [TestMethod]
    public void SubscriptionsTo_ProfileSelectedMessage_Should_Run_EventSubscription_Success()
    {
        // Scenario: User selects a server profile
        // Given a user has SteamCMD and the Enshrouded server installed
        // When a profile is selected
        // And it's server is not running
        // Then the Start Server button should be visible
        // And the Install Server button should be visible
        // And the Update Server button should be visible
        // And the Stop Server button should be visible

        // Arrange
        _adminPanelView.StartServerButtonVisible = false;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.InstallServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = false;

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(true);
        _enshroudedServerService.IsRunning(Arg.Any<string>()).Returns(false);

        _versionManagementService.ServerUpdateCheck(Arg.Any<string>()).ReturnsForAnyArgs(Color.Yellow);
        _adminPanelView.UpdateServerButtonBorderColor = Color.Yellow;


        // Act
        EventAggregator.Instance.Publish(new ProfileSelectedMessage(new ServerProfile() { Name = "TestServer" }));

        // Assert
        _adminPanelView.StartServerButtonVisible.Should().BeTrue();
        _adminPanelView.StopServerButtonVisible.Should().BeFalse();
        _adminPanelView.InstallServerButtonVisible.Should().BeFalse();
        _adminPanelView.UpdateServerButtonVisible.Should().BeTrue();
    }

    [TestMethod]
    public void ClickingOn_WindowsFirewall_Should_Open_WindowsFirewall_Success()
    {
        // Scenario: User clicks on the Windows Firewall button
        // When the user clicks on the Windows Firewall button
        // Then the Windows Firewall program should open

        // Arrange
        // Act
        _adminPanelView.WindowsFirewallButtonClicked += Raise.Event();

        // Assert
        _systemProcessService.Received().Start(Constants.ProcessNames.EXPLORER_EXE, Constants.Files.WINDOWS_FIREWALL);

    }

    [TestMethod]
    public void ClickingOn_StartServer_Should_Start_Server_Success()
    {
        // Scenario: User clicks on the Start Server button
        // Given a user has selected a server profile
        // And the server is not running
        // And the server profile has no discord settings
        // And the server has no AutoBackup settings
        // When the user clicks on the Start Server button
        // Then the server should start
        // And the Start Server button should be hidden
        // And the Stop Server button should be visible
        // And the Update Server button should be hidden

        // Arrange
        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = false;

        //EventAggregator.Instance.Publish(new ProfileSelectedMessage(new ServerProfile() { Name = "TestServer" }));
        var profiles = new List<ServerProfile>()
        {
            new ServerProfile{ Name = "TestServer" }
        };

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(true, false);
        _enshroudedServerService.IsRunning(Arg.Any<string>()).Returns(true);
        _profileService.LoadServerProfiles(Arg.Any<JsonSerializerSettings>()).Returns(profiles);

        // Act
        _adminPanelView.StartServerButtonClicked += Raise.Event();

        // Assert
        _enshroudedServerService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
        _backupService.DidNotReceive().StartAutoBackup(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>());
        _discordService.DidNotReceive().ServerOnline(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        _adminPanelView.StartServerButtonVisible.Should().BeFalse();
        _adminPanelView.StopServerButtonVisible.Should().BeTrue();
        _adminPanelView.UpdateServerButtonVisible.Should().BeFalse();
    }

    [TestMethod]
    public void ClickingOn_StartServer_Should_Start_Server_And_AutoBackup_Success()
    {
        // Scenario: User clicks on the Start Server button
        // Given a user has selected a server profile
        // And the server is not running
        // And the server profile has no discord settings
        // And the server has AutoBackup Settings
        // When the user clicks on the Start Server button
        // Then the server should start
        // And the Start Server button should be hidden
        // And the Stop Server button should be visible
        // And the Update Server button should be hidden

        // Arrange
        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = false;

        _serverProfileUnderTest.AutoBackup = new AutoBackup()
        {
            Enabled = true,
            Interval = 0,
            MaxiumBackups = 0
        };

        var discordSettingsFile = Path.Join(Constants.Paths.DEFAULT_PROFILES_PATH, Constants.Files.DISCORD_JSON);

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(true);
        _fileSystemService.FileExists(discordSettingsFile).Returns(false);
        _enshroudedServerService.IsRunning(Arg.Any<string>()).Returns(true);

        // Act
        _adminPanelView.StartServerButtonClicked += Raise.Event();

        // Assert
        _enshroudedServerService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
        _backupService.Received().StartAutoBackup(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>());
        _discordService.DidNotReceive().ServerOnline(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        _adminPanelView.StartServerButtonVisible.Should().BeFalse();
        _adminPanelView.StopServerButtonVisible.Should().BeTrue();
        _adminPanelView.UpdateServerButtonVisible.Should().BeFalse();
    }

    [TestMethod]
    public void ClickingOn_StartServer_Should_Start_Server_And_Send_Discord_Message_Success()
    {
        // Scenario: User clicks on the Start Server button
        // Given a user has selected a server profile
        // And the server is not running
        // And the server profile has discord settings
        // And the server has no AutoBackup settings
        // When the user clicks on the Start Server button
        // Then the server should start
        // And the Start Server button should be hidden
        // And the Stop Server button should be visible
        // And the Update Server button should be hidden

        // Arrange
        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = false;

        //EventAggregator.Instance.Publish(new ProfileSelectedMessage(new ServerProfile() { Name = "TestServer" }));
        var profiles = new List<ServerProfile>()
        {
            new ServerProfile{ Name = "TestServer" }
        };

        var discordSettings = @"{
            ""DiscordUrl"": ""TestUrl"",
            ""Enabled"": true,
            ""StartEnabled"": true,
            ""StopEnabled"": true,
            ""UpdatingEnabled"": true,
            ""BackupEnabled"": true,
            ""EmbedEnabled"": true,
            ""ServerOnlineMsg"": ""ServerOnline"",
            ""ServerStoppedMsg"": ""ServerStopped"",
            ""ServerUpdatingMsg"": ""ServerUpdating"",
            ""BackupMsg"": ""Backup""}";

        var serverSettings = @"{
            ""name"": ""TestServer"",
            ""password"": ""TestPassword"",
            ""saveDirectory"": ""TestSaveDirectory"",
            ""logDirectory"": ""TestLogDirectory"",
            ""ip"": ""TestIp"",
            ""gamePort"": 0,
            ""queryPort"": 0,
            ""slotCount"": 0
        }";

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(true, true);
        _fileSystemService.ReadFile(Arg.Any<string>()).Returns(discordSettings, serverSettings);
        _enshroudedServerService.IsRunning(Arg.Any<string>()).Returns(true);
        _profileService.LoadServerProfiles(Arg.Any<JsonSerializerSettings>()).Returns(profiles);

        // Act
        _adminPanelView.StartServerButtonClicked += Raise.Event();

        // Assert
        _enshroudedServerService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
        _backupService.DidNotReceive().StartAutoBackup(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>());
        _discordService.Received().ServerOnline(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        _adminPanelView.StartServerButtonVisible.Should().BeFalse();
        _adminPanelView.StopServerButtonVisible.Should().BeTrue();
        _adminPanelView.UpdateServerButtonVisible.Should().BeFalse();
    }

    [TestMethod]
    public void ClickingOn_StopServer_Should_Stop_Server_Success()
    {
        // Scenario: User clicks on the Stop Server button
        // Given a user has selected a server profile
        // And the server is running
        // When the user clicks on the Stop Server button
        // Then the server should stop
        // And the Start Server button should be visible
        // And the Stop Server button should be hidden
        // And the Update Server button should be visible

        // Arrange
        _adminPanelView.StartServerButtonVisible = false;
        _adminPanelView.StopServerButtonVisible = true;
        _adminPanelView.UpdateServerButtonVisible = false;
        _adminPanelView.InstallServerButtonVisible = false;

        _enshroudedServerService.IsRunning(Arg.Any<string>()).Returns(true);

        // Act
        _adminPanelView.StopServerButtonClicked += Raise.Event();

        // Assert
        _enshroudedServerService.Received().Stop(Arg.Any<string>());
        _adminPanelView.StartServerButtonVisible.Should().BeTrue();
        _adminPanelView.StopServerButtonVisible.Should().BeFalse();
        _adminPanelView.UpdateServerButtonVisible.Should().BeTrue();
    }

    [TestMethod]
    public void ClickingOn_InstallServer_Should_Install_Server_Success()
    {
        // Scenario: User clicks on the Install Server button
        // Given a user has selected a server profile
        // And the server is not installed
        // When the user clicks on the Install Server button
        // Then the server should install
        // And the Start Server button should be visible
        // And the Stop Server button should be hidden
        // And the Update Server button should be visible with a green border

        // Arrange
        _adminPanelView.StartServerButtonVisible = false;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = true;

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(false);
        _versionManagementService.ServerUpdateCheck(Arg.Any<string>()).Returns(Color.Green);


        // Act
        _adminPanelView.InstallServerButtonClicked += Raise.Event();

        // Assert

        // TODO: Refactor EventAggregator as a normal class and use DI to configure it as a singleton
        // We can not test that the EventAggregator called it's methods, because there's
        // no way to stub the singleton instance of EventAggregator.
        //EventAggregator.Instance = Substitute.For<IEventAggregator>();
        //EventAggregator.Instance.Received().Publish(Arg.Any<ServerInstallStoppedMessage>());
        //EventAggregator.Instance.Received().Publish(Arg.Any<ServerInstallStartedMessage>());

        _enshroudedServerService.Received().InstallUpdate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        _versionManagementService.Received().ServerUpdateCheck(Arg.Any<string>());

        _adminPanelView.StartServerButtonVisible.Should().BeTrue();
        _adminPanelView.StopServerButtonVisible.Should().BeFalse();
        _adminPanelView.InstallServerButtonVisible.Should().BeFalse();
        _adminPanelView.UpdateServerButtonVisible.Should().BeTrue();
        _adminPanelView.UpdateServerButtonBorderColor.Should().Be(Color.Green);
    }

    [TestMethod]
    public void ClickingOn_UpdateServer_Should_Update_Server_Success()
    {
        // Scenario: User clicks on the Update Server button
        // Given a user has selected a server profile
        // And the server is installed
        // When the user clicks on the Update Server button
        // Then the server should update successfully
        // And the Start Server button should be visible
        // And the Stop Server button should be hidden
        // And the Update Server button should be visible with a green border

        // Arrange
        _adminPanelView.StartServerButtonVisible = true;
        _adminPanelView.StopServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonVisible = true;
        _adminPanelView.InstallServerButtonVisible = false;
        _adminPanelView.UpdateServerButtonBorderColor = Color.Yellow;

        _fileSystemService.FileExists(Arg.Any<string>()).Returns(false);
        _versionManagementService.ServerUpdateCheck(Arg.Any<string>()).Returns(Color.Green);

        // Act
        _adminPanelView.UpdateServerButtonClicked += Raise.Event();

        // Assert
        _enshroudedServerService.Received().InstallUpdate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        _versionManagementService.Received().ServerUpdateCheck(Arg.Any<string>());

        _adminPanelView.StartServerButtonVisible.Should().BeTrue();
        _adminPanelView.StopServerButtonVisible.Should().BeFalse();
        _adminPanelView.InstallServerButtonVisible.Should().BeFalse();
        _adminPanelView.UpdateServerButtonVisible.Should().BeTrue();
        _adminPanelView.UpdateServerButtonBorderColor.Should().Be(Color.Green);
    }

    [TestMethod]
    public void ClickingOn_SaveBackup_Should_Save_Backup_Success()
    {
        // Scenario: User clicks on the Save Backup button
        // Given a user has selected a server profile
        // When the user clicks on the Save Backup button
        // Then a backup should be saved

        // Arrange
        // See constructor for profile setup

        // Act
        _adminPanelView.SaveBackupButtonClicked += Raise.Event();

        // Assert
        _backupService.Received().Save(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }

    [TestMethod]
    public void ClickingOn_OpenBackupFolder_Should_Open_Backup_Folder_Success()
    {
        // Scenario: User clicks on the Open Backup Folder button
        // When the user clicks on the Open Backup Folder button
        // Then the backup folder should open

        // Arrange
        // See constructor for profile setup

        // Act
        _adminPanelView.OpenBackupFolderButtonClicked += Raise.Event();

        // Assert
        _fileSystemService.Received().CreateDirectory(Arg.Any<string>());
        _systemProcessService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
    }

    [TestMethod]
    public void ClickingOn_OpenSavegameFolder_Should_Open_Savegame_Folder_Success()
    {
        // Scenario: User clicks on the Open Savegame Folder button
        // When the user clicks on the Open Savegame Folder button
        // Then the savegame folder should open

        // Arrange
        // See constructor for profile setup

        // Act
        _adminPanelView.OpenSavegameFolderButtonClicked += Raise.Event();

        // Assert
        _fileSystemService.Received().CreateDirectory(Arg.Any<string>());
        _systemProcessService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
    }

    [TestMethod]
    public void ClickingOn_OpenLogFolder_Should_Open_Log_Folder_Success()
    {
        // Scenario: User clicks on the Open Log Folder button
        // When the user clicks on the Open Log Folder button
        // Then the log folder should open

        // Arrange
        // See constructor for profile setup

        // Act
        _adminPanelView.OpenLogFolderButtonClicked += Raise.Event();

        // Assert
        _fileSystemService.Received().CreateDirectory(Arg.Any<string>());
        _systemProcessService.Received().Start(Arg.Any<string>(), Arg.Any<string>());
    }
}