﻿namespace Enshrouded_Server_Manager;
public static class Constants
{
    public const int BUTTON_DOWN = 0xA1;
    public const int CAPTION = 0x2;
    public const string STEAM_APP_ID = "2278520";

    public static class Paths
    {
        public const string SERVER_PATH = "./Servers";
        public const string DEFAULT_PROFILES_PATH = "./ServerProfiles";
        public const string BACKUPS_FOLDER = "./Backups";
        public const string CACHE_DIRECTORY = "./cache";
        public const string AUTOBACKUPS_FOLDER = $"{BACKUPS_FOLDER}/AutoBackup";
        public const string ENSHROUDED_SAVE_GAME_DIRECTORY = "./savegame";
        public const string ENSHROUDED_LOGS_DIRECTORY = "./logs";
        public const string GAME_SERVER_SAVE_FOLDER = "savegame";
        public const string GAME_SERVER_LOGS_FOLDER = "logs";
    }

    public static class Files
    {
        public const string PID_JSON = "pid.json";
        public const string GAME_SERVER_CONFIG_JSON = "enshrouded_server.json";
        public const string SERVER_PROFILES_JSON = "server_profiles.json";
        public const string GAME_SERVER_EXE = "enshrouded_server.exe";
        public const string WINDOWS_FIREWALL = @"c:\windows\system32\wf.msc";
    }

    public static class Errors
    {
        public const string BACKUP_ERROR = "Backup Failed";
        public const string BACKUP_ERROR_MESSAGE = "An error occured while creating the backup";

        public const string AUTOBACKUP_ERROR = "AutoBackup Failed";
        public const string AUTOBACKUP_ERROR_MESSAGE = "An error occured while creating the autobackup";

        public const string SERVER_RUNNING_ERROR = "Server is Running";
        public const string SERVER_RUNNING_ERROR_MESSAGE = "This Server Profile is currently running, and cannot be changed.";

        public const string DELETE_PROFILE_ERROR = "Error Deleting Server Profile";
        public const string DELETE_PROFILE_ERROR_MESSAGE = "The following error occured while deleting Server Profile: {0}";

        public const string BACKUP_CONFIGURATION_ERROR = "No Server Profile Selected";
        public const string BACKUP_CONFIGURATION_ERROR_MESSAGE = "Please select the profile you want to configure.";

        public const string PROFILE_NAME_CHANGE_ERROR = "Error Changing Server Profile Name";
        public const string PROFILE_NAME_CHANGE_ERROR_MESSAGE = "The Following error occured while changing Server Profile name: {0}";

        public const string SERVER_START_ERROR = "Error Starting Server";
        public const string SERVER_START_ERROR_MESSAGE = "The following error occured while starting the server: {0}";

        public const string SERVER_UPDATE_ERROR = "Error Updating Server";
        public const string SERVER_UPDATE_ERROR_MESSAGE = "The following error occured while updating the server: {0}";

        public const string SERVER_PROFILES_NOT_FOUND_ERROR = "Error Reading Profile Data";
        public const string SERVER_PROFILES_NOT_FOUND_ERROR_MESSAGE = "Unable to retrieve Server Profile data. The file may have been lost or moved. Please attempt to restore the file restart the application.";

        public const string SERVER_PROFILE_EMPTY_ERROR = "Profile Name Not Provided";
        public const string SERVER_PROFILE_EMPTY_ERROR_MESSAGE = "The Server Profile name can not be empty";

        public const string SERVER_PROFILE_INVALID_CHARACTERS_ERROR = "Invalid Characters";
        public const string SERVER_PROFILE_INVALID_CHARACTERS_ERROR_MESSAGE = "The Server Profile name contains invalid characters. Use only those characters acceptable by the Windows File System";

        public const string STEAM_CMD_DOWNLOAD_ERROR = "Error Extracting Steam CMD";
        public const string STEAM_CMD_DOWNLOAD_ERROR_MESSAGE = "The following error appeared while extracting: {0}";

        public const string STEAM_CMD_INSTALL_ERROR = "Error Installing Steam CMD";
        public const string STEAM_CMD_INSTALL_ERROR_MESSAGE = "The following error appeared while installing SteamCMD: {0}";
    }

    public static class Warnings
    {
        public const string DELETE_PROFILE_WARNING = "Delete Profile?";
        public const string DELETE_PROFILE_WARNING_MESSAGE = "Are you sure you want to delete this profile and all related server files?";
    }

    public static class ButtonText
    {
        public const string SAVED_SUCCESS = "Saved!";
        public const string SHOW_PASSWORD = "Show";
        public const string HIDE_PASSWORD = "Hide";

    }

    public static class ProcessNames
    {
        public const string EXPLORER_EXE = "explorer.exe";
        public const string STEAM_CMD_EXE = @"./SteamCMD/steamcmd.exe";
    }

    public static class ReservedProfileNames
    {
        public const string AUTO_BACKCUP = "AutoBackup";
    }

    public static class Colors
    {
        private static readonly Color DARK_BLUE = Color.FromArgb(255, 0, 0, 40);
        private static readonly Color BLUE_GRAY = Color.FromArgb(255, 115, 115, 137);

        public static readonly Color BUTTON_BACKGROUND = DARK_BLUE;
        public static readonly Color BUTTON_BACKGROUND_DISABLED = BLUE_GRAY;
        public static readonly Color BUTTON_BORDER = BLUE_GRAY;
        public static readonly Color BUTTON_BORDER_DISABLED = DARK_BLUE;

    }
}