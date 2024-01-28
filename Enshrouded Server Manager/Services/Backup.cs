using System.IO.Compression;

namespace Enshrouded_Server_Manager.Services;

public class Backup
{
    private Folder? _folder;
    private const string BACKUPS_FOLDER = "./Backups";
    private const string AUTO_BACKUPS_FOLDER = BACKUPS_FOLDER + "/AutoBackup";
    private string _datetimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");


    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(String saveFileDirectory, String profileName, String fileToCopy, String locationOfFileToCopy)
    {
        _folder = new Folder();

        _folder.Create(saveFileDirectory);
        _folder.Create($"{BACKUPS_FOLDER}/{profileName}");

        if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
        {
            File.Delete($"{saveFileDirectory}/{fileToCopy}");
        }

        if (File.Exists($"{locationOfFileToCopy}/{fileToCopy}"))
        {
            File.Copy($"{locationOfFileToCopy}/{fileToCopy}", $"{saveFileDirectory}/{fileToCopy}");
        }


        try
        {
            ZipFile.CreateFromDirectory(saveFileDirectory, $"{BACKUPS_FOLDER}/{profileName}/backup-{_datetimeString}.zip");
            MessageBox.Show(@$"Backup saved at: ""{BACKUPS_FOLDER}/{profileName}/backup-{_datetimeString}.zip""",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(@$"An error occured while creating the zip file: {ex.Message.ToString()}",
                "Error while zipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
        {
            File.Delete($"{saveFileDirectory}/{fileToCopy}");
        }

    }

    public async void StartAutoBackup(string saveFileDirectory, string profileName, int interval, int maximumBackups, CancellationToken token, String fileToCopy, String locationOfFileToCopy)
    {
        if (interval < 1 || maximumBackups < 1)
        {
            return;
        }

        _folder = new Folder();

        _folder.Create(saveFileDirectory);
        _folder.Create($"{AUTO_BACKUPS_FOLDER}/{profileName}");

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(interval));

        while (await timer.WaitForNextTickAsync(token))
        {
            //ZipFile.CreateFromDirectory(saveFileDirectory, $"{AUTO_BACKUPS_FOLDER}/{profileName}/backup-{_datetimeString}.zip");


            // logic of manual Backup
            if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
            {
                File.Delete($"{saveFileDirectory}/{fileToCopy}");
            }

            if (File.Exists($"{locationOfFileToCopy}/{fileToCopy}"))
            {
                File.Copy($"{locationOfFileToCopy}/{fileToCopy}", $"{saveFileDirectory}/{fileToCopy}");
            }


            try
            {
                // changed backup folder to autobackup folder
                ZipFile.CreateFromDirectory(saveFileDirectory, $"{AUTO_BACKUPS_FOLDER}/{profileName}/backup-{_datetimeString}.zip");
                MessageBox.Show(@$"Backup saved at: ""{BACKUPS_FOLDER}/{profileName}/backup-{_datetimeString}.zip""",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"An error occured while creating the zip file: {ex.Message.ToString()}",
                    "Error while zipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
            {
                File.Delete($"{saveFileDirectory}/{fileToCopy}");
            }
            //
            DeleteOldestBackup(saveFileDirectory, maximumBackups);
        }
    }

    private void DeleteOldestBackup(string backupDirectory, int maximumBackups)
    {
        var directory = new DirectoryInfo(backupDirectory);
        var zipFiles = directory.GetFiles("*.zip");
        if (zipFiles.Length > maximumBackups)
        {
            var oldestZip = zipFiles.FirstOrDefault();
            if (oldestZip != null)
            {
                oldestZip.Delete();
            }
        }
    }

    public int GetBackupCount(string profileName)
    {
        throw new NotImplementedException();
    }

    public long GetDiskConsumption(string profileName)
    {
        // find all backups for the selected profile
        var directory = new DirectoryInfo($"{AUTO_BACKUPS_FOLDER}/{profileName}");
        var files = directory.GetFiles("*.zip");

        // sum up the size of all backups
        long size = 0;
        foreach (var file in files)
        {
            size += file.Length;
        }

        return size;
    }
}
