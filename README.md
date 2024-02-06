# Current version: 0.4.0


This little tool is an experimental enshrouded server manager.

## Select a server profile, install the server, and start hosting.
![image](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/d7c6b539-5fc2-4722-ab5b-e9291a76cf35)

## Manage your server profiles by adding renaming and deleting them.
![image](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/5182b41d-3d49-48bd-93b0-6b52f48451f3)

## Configure Automatic Backup to save your world files on an interval
![image](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/a95ec730-bae0-4329-8225-bb9bee5a5919)

## Update your Discord with Server information
![image](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/32116fba-afb2-40ca-a16c-9f571af696af)
![image](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/106ff404-e5c0-4d71-86be-4f691214e7c7)


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
