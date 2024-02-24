# ESM - Enshrouded Server Manager
![][version] ![][downloads]

[version]: https://img.shields.io/github/v/release/crazyloon/Enshrouded-Server-Manager?logo=github
[downloads]: https://img.shields.io/github/downloads/crazyloon/enshrouded-server-manager/total.svg

This is a tool to help you manage your Dedicated Enshrouded servers.

## Select a server profile, install the server, and start hosting.
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/714d5977-bb7f-4951-9eff-f4440a3b3bff)

## Manage your server profiles by adding renaming and deleting them.
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/e0fd96a8-69df-4e44-8eb2-128f583c7435)

## Configure Automatic Backup to save your world files on an interval
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/592ce4a1-c18e-4f87-b5f0-3b5153c69855)

## Restore backups
Backups can be restored from a zipped backup, zipped automatic backup or a world file. Alternatively, set the restore file path to your automatic backup directory to always restore from the latest automatic backup. Here you can also configure your scheduled restarts to restore from your selected backup location
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/c225f975-9406-49e8-8473-acc99d77c913)

## Set an automatic restart schedule when your server starts, or at a specific date and time
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/9651943d-01d6-4e2f-8065-d03bf11311e9)

## Update your Discord with Server information
![image](https://github.com/Crazyloon/Enshrouded-Server-Manager/assets/8146917/6d21899b-6c31-416f-8d4a-5c4f74a9a692)



## Download
Click on the Releases link on the right-hand side of the repo, download the zip and extract it to your desired directory.
This is where all the related files will be saved once the app is running.

## Usage
The app starts and creates a default semi-random profile. You can edit the profile name in the Manage Profiles tab, more on that below.

Use the Server Profile combo-box selector to switch profiles at any time. The currently selected profile will be referenced when you click any "Server Profile" specific buttons, like Start Server, Install Server, Save Backup, etc.

### Launch a server
To launch a server for the first time: 
- Click Install SteamCMD.
- Manage your Windows Firewall to open TCP/UPD ports for the GamePort and QueryPort.
- Select the server profile you wish to use.
- Click Install Server.
- Once the server is installed, click Start Server.
- This should launch a server that will appear in the games list of Enshrouded.

### Manage your profiles
Under the Manage Profiles tab, you can add, rename, and delete server profiles.
To Add a Profile, click the + symbol next to Add New Profile. This will create a new server with a semi-random name, like ServerABC123.
To Rename a Profile, click on the profile name you wish to modify. The name will appear in the Profile Name text box. Edit the server name here, and click Save Changes to rename your first server.
To Delete a Profile, click on the profile name you wish to delete, then click the Delete Selected button. You must confirm you wish to delete by clicking yes in the window that appears.
- Note: Deleting a profile will remove the profile and the underlying server files, but any backups you create will be retained. ONLY delete a profile if you are sure you have backed up the save files, or you are certain you don't want them anymore.

### Automatically backup your world files
Under the Auto Backup tab, you have the option to select your server profile and configure an automatic backup schedule to save a zip file with the contents of your savegame directory, where your world is stored, and the current server configuration file.
Check the Enable Backups box to turn backups on, then set an interval of 60 and a maximum number of backups of 10 to configure the system to save a backup every hour, up to a maximum of 10 backups. Once the maximum backup limit is reached, the oldest backups will be deleted when a new backup is saved.
- Note: Automatic backups are separate from manual backups. Neither one will overwrite the other, nor does the maximum backups configuration affect manual backups
- Note: Auto Backup settings will be applied when a server starts. If your server is running, your settings will not be applied until you restart the server.

### Add your discord webhook to update your community
Under the Discord tab, paste in your Discord server's Webhook and check Enable Discord to update your community whenever the server starts, stops, updates, or creates a backup.
If you need more information about creating a Webhook for your server, see the official [Discord Webhooks Documentation](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks)

## Notes
Every Server Profile has its own install directory and configuration.
You are able to make backups (.zip) of your worldsave files for each server.
(If you change your server name, the backup folder name will change, but the zip folder name will not)

Important: 
If you delete a profile, it is your own responsibility to backup your worldsave before, as these will be lost when you delete a profile.

Can't give any support because of time issues. Contributors and Pull Requests are welcome.

Use at own risk!


Enshrouded is a registered product of Keen Games GmbH.
