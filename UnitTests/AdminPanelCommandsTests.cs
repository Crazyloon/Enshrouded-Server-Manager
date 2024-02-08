using Enshrouded_Server_Manager.Commands;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Services.Interfaces;
using NSubstitute;

namespace UnitTests;

[TestClass]
public class AdminPanelCommandsTests
{
    [TestMethod]
    public void ClickingOn_InstallSteamCMD_Should_InstallSteamCMD_Success()
    {
        //// Arrange
        bool actualMessageResult = false;
        bool expectedMessageResult = true;
        var steamCMDInstaller = Substitute.For<ISteamCMDInstallerService>();
        var fileSystemManager = Substitute.For<IFileSystemService>();
        fileSystemManager.FileExists(Arg.Any<string>()).Returns(true);

        EventAggregator.Instance.Subscribe<SteamCmdInstalledMessage>(a => actualMessageResult = a.IsInstalled);
        var command = new InstallSteamCmdCommand(steamCMDInstaller, fileSystemManager);

        //// Act
        command.Execute();

        //// Assert
        steamCMDInstaller.Received().Install();
        Assert.AreEqual(expectedMessageResult, actualMessageResult);
        steamCMDInstaller.Received().Start();
    }
}