namespace Enshrouded_Server_Manager.Const;
public static class Constants
{
    public static class Paths
    {
        // Server Tool SteamId
        public const string STEAM_APP_ID = "2278520";
        // Game Server exe Name
        public const string GAME_SERVER_EXE = @"/enshrouded_server.exe";
        // Game Server config Name
        public const string GAME_SERVER_CONFIG = @"/enshrouded_server.json";
        // Savegame folder name after Server folder
        public const string GAME_SERVER_SAVE_FOLDER = @"/savegame";
        // Logs folder name after Server folder
        public const string GAME_SERVER_LOGS_FOLDER = @"/logs";

        public const string STEAM_CMD_EXE = @"./SteamCMD/steamcmd.exe";
        public const string SERVER_PATH = @"./Servers/";
        public const string DEFAULT_PROFILES_PATH = @"./ServerProfiles/";
        public const string SERVER_PROFILES_JSON = "server_profiles.json";
        public const string FIREWALL_PATH = @"c:\windows\system32\wf.msc";
        public const string BACKUPS_FOLDER = "./Backups";
        public const string CACHE_PATH = @"./cache/";
        public const string PID_CONFIG = $"pid.json";
        public const string AUTOBACKUPS_FOLDER = $"{BACKUPS_FOLDER}/AutoBackup";
    }

    public const int BUTTON_DOWN = 0xA1;
    public const int CAPTION = 0x2;
}
