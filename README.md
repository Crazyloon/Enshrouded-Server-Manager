# Current version: 0.0.5

This little tool is an experimental enshrouded server manager.

## Select a server profile, install the server, and start hosting.
![Screenshot 2024-01-23 205508](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/46ad5b0b-b2ef-4bb3-95bb-6dbd44a06182)

## Manage your server profiles by adding renaming and deleting them.
![Screenshot 2024-01-23 205606](https://github.com/ISpaikI/Enshrouded-Server-Manager/assets/8146917/70cf7792-f93d-47f2-9350-daad8076158e)

## Download
Click on the Releases link on the right-hand side of the repo, download the zip and extract it to your desired directory.
This is where all the related files will be saved once the app is running.

## Usage
The app starts and creates a default semi-random profile. You can edit the profile name in the Manage Profiles tab, more on that below.

Use the Server Profile combo-box selector to switch profiles at any time. The currently selected profile will be referenced when you click any "Server Profile" specific buttons, like Start Server, Install Server, Save Backup, etc.

To launch a server for the first time: 
- Click Install SteamCMD.
- Manage your Windows Firewall to open TCP/UPD ports for the GamePort and QueryPort.
- Select the server profile you wish to use.
- Click Install Server.
- Once the server is installed, click Start Server.
- This should launch a server for which will appear in the games list of Enshrouded.

## Notes
Every Server Profile has its own install directory and configuration.
You are able to make backups (.zip) of your worldsave files for each server.
(If you change your server name, the backup folder name will change, but the zip folder name will not)

Windowname of the server applications should be named as follow:
ESM Server - "Servername"

Important: 
If you delete a profile, it is your own responsibility to backup your worldsave before, as these will be lost when you delete a profile.

Can't give any support because of time issues. Contributors and Pull Requests are welcome.

Use at own risk!


Enshrouded is a registered product of Keen Games GmbH.
