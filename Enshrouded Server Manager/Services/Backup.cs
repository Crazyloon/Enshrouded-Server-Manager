using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.Compression;

namespace Enshrouded_Server_Manager.Services;

public class Backup
{
    private Folder? _folder;
    private const string BACKUPS_FOLDER = "./Backups";
    private const string AUTO_BACKUPS_FOLDER = BACKUPS_FOLDER + "/AutoBackup";
    private string _dateTimeString;

    public event EventHandler<AutoBackupSuccessEventArgs> AutoBackupSuccess;

    /// <summary>
    /// Save a zip file of the location you set in "sourcefolder"
    /// </summary>
    public void Save(String saveFileDirectory, String profileName, String fileToCopy, String locationOfFileToCopy)
    {
        _dateTimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
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
            ZipFile.CreateFromDirectory(saveFileDirectory, $"{BACKUPS_FOLDER}/{profileName}/backup-{_dateTimeString}.zip");
            MessageBox.Show(@$"Backup saved at: ""{BACKUPS_FOLDER}/{profileName}/backup-{_dateTimeString}.zip""",
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

    public async void StartAutoBackup(string saveFileDirectory, string profileName, int interval, int maximumBackups, String fileToCopy, String locationOfFileToCopy)
    {
        if (interval < 1 || maximumBackups < 1)
        {
            return;
        }

        _folder = new Folder();

        _folder.Create(saveFileDirectory);
        _folder.Create($"{AUTO_BACKUPS_FOLDER}/{profileName}");

        var timer = new PeriodicTimer(TimeSpan.FromMinutes(interval));
        if (!Server.IsRunning(profileName))
        {
            timer.Dispose();
            return;
        }
        var input = File.ReadAllText($"./cache/{profileName}pid.json");
        EnshroudedServerProcess? serverProcessInfo = JsonConvert.DeserializeObject<EnshroudedServerProcess>(input);

        while (await timer.WaitForNextTickAsync())
        {
            // check if the server is running

            try
            {
                Process.GetProcessById(serverProcessInfo.Id);

            }
            catch
            {
                timer.Dispose();
                return;
            }

            try
            {
                if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
                {
                    File.Delete($"{saveFileDirectory}/{fileToCopy}");
                }

                if (File.Exists($"{locationOfFileToCopy}/{fileToCopy}"))
                {
                    File.Copy($"{locationOfFileToCopy}/{fileToCopy}", $"{saveFileDirectory}/{fileToCopy}");
                }

                _dateTimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                // changed backup folder to autobackup folder
                ZipFile.CreateFromDirectory(saveFileDirectory, $"{AUTO_BACKUPS_FOLDER}/{profileName}/backup-{_dateTimeString}.zip");

                if (File.Exists($"{saveFileDirectory}/{fileToCopy}"))
                {
                    File.Delete($"{saveFileDirectory}/{fileToCopy}");
                }

                DeleteOldestBackup($"{AUTO_BACKUPS_FOLDER}/{profileName}", maximumBackups);
                OnAutoBackupSuccess(new AutoBackupSuccessEventArgs { ProfileName = profileName });
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"An error occured while creating the zip file: {ex.Message}",
                    "Error while zipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }

    public int GetBackupCount(string profileName)
    {
        if (!Directory.Exists($"{AUTO_BACKUPS_FOLDER}/{profileName}"))
        {
            return 0;
        }

        // find the number of backups for the selected profile
        var directory = new DirectoryInfo($"{AUTO_BACKUPS_FOLDER}/{profileName}");
        var files = directory.GetFiles("*.zip");

        return files.Length;
    }

    public long GetDiskConsumption(string profileName)
    {
        if (!Directory.Exists($"{AUTO_BACKUPS_FOLDER}/{profileName}"))
        {
            return 0;
        }

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

    protected virtual void OnAutoBackupSuccess(AutoBackupSuccessEventArgs e)
    {
        AutoBackupSuccess?.Invoke(this, e);
    }
}
