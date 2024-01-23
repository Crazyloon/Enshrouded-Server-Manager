using System.IO.Compression;

namespace Enshrouded_Server_Manager.Services;

public class Backup
{
    private Folder? _folder;
    private const string SERVER_PATH = @"./Servers/";
    private const string BACKUPS_FOLDER = "/Backups";

    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(String serverSaveFolder, String serverName)
    {
        _folder = new Folder();

        //Format DateTime Now
        string datetimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        _folder.Create(serverSaveFolder);
        _folder.Create($"{SERVER_PATH}{serverName}{BACKUPS_FOLDER}");

        try
        {
            ZipFile.CreateFromDirectory(serverSaveFolder, $"{SERVER_PATH}{serverName}{BACKUPS_FOLDER}/backup-{datetimeString}.zip");
            MessageBox.Show(@$"Backup saved at: ""{SERVER_PATH}{serverName}{BACKUPS_FOLDER}/backup-{datetimeString}.zip""",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(@$"An error occured while creating the zip file: {ex.Message.ToString()}",
                "Error while zipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

    }
}