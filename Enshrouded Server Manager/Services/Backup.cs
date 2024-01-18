using System.IO.Compression;

namespace Enshrouded_Server_Manager.Services
{
    public class Backup
    {
        private Folder? _folder;
        private string _sourcezipfolder = @"./Servers/Backups/";

        /// <summary>
        /// Save a zip file of the location you set in "sourcefolder"
        /// </summary>
        public void Save(String ServerSaveFolder, String ServerNumber)
        {
            _folder = new Folder();

            //Format DateTime Now
            string datetimeString = DateTime.Now.ToString().Replace(":", "-");
            
            _folder.create(_sourcezipfolder + "Server" + ServerNumber);

            _folder.create(ServerSaveFolder);

            try
            {
                ZipFile.CreateFromDirectory(ServerSaveFolder, _sourcezipfolder + "Server" + ServerNumber + "/Server" + ServerNumber + " Backup " + datetimeString + ".zip");
                MessageBox.Show("Backup saved! Name: Server" + ServerNumber + " Backup " + datetimeString + ".zip",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occured while creating the zip file: " + ex.Message.ToString(),
                    "Error while zipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }

}