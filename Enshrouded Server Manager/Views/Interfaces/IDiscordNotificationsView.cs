﻿namespace Enshrouded_Server_Manager.Views;

public interface IDiscordNotificationsView
{
    event EventHandler SaveDiscordNotificationsSettingsClicked;
    event EventHandler TestDiscordMessageClicked;
    event EventHandler DiscordSettingsLoad;

    bool IsDiscordNotificationsEnabled { get; set; }
    bool IsEmbedsEnabled { get; set; }
    bool IsNotifyOnStartEnabled { get; set; }
    bool IsNotifyOnStopEnabled { get; set; }
    bool IsNotifyOnUpdateEnabled { get; set; }
    bool IsNotifyOnBackupEnabled { get; set; }
    bool IsNotifyOnBackupRestoreEnabled { get; set; }
    bool IsNotifyOnServerRestartEnabled { get; set; }

    bool IsLongResetMessageEnabled { get; set; }
    bool IsMediumResetMessageEnabled { get; set; }
    bool IsShortResetMessageEnabled { get; set; }
    bool IsSoonResetMessageEnabled { get; set; }
    bool IsImminentResetMessageEnabled { get; set; }



    string ServerStartedMessage { get; set; }
    string ServerStoppedMessage { get; set; }
    string ServerUpdatingMessage { get; set; }
    string BackupCreatedMessage { get; set; }
    string BackupRestoredMessage { get; set; }
    string ServerRestartMessage { get; set; }

    string WebhookUrl { get; set; }

    void AnimateSaveButton();
}