namespace Enshrouded_Server_Manager.Services;

public class FileSystemManager
{
    public void Create(string Foldername)
    {
        Directory.CreateDirectory(Foldername);
    }
    /// <summary>
    /// Check for an existing folder and delete it
    /// </summary>
    public void Delete(string Foldername)
    {
        if (Directory.Exists(Foldername))
        {
            Directory.Delete(Foldername, true);
        }
    }
}
