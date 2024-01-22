namespace Enshrouded_Server_Manager.Services;

public class Folder
{
    /// <summary>
    /// look if folder exists if not create
    /// </summary>
    public void Create(String Foldername)
    {
        if (!Directory.Exists(Foldername))
        {
            Directory.CreateDirectory(Foldername);
        }
    }

    /// <summary>
    /// Check for an existing folder and delete it
    /// </summary>
    public void Delete(String Foldername)
    {
        if (Directory.Exists(Foldername))
        {
            Directory.Delete(Foldername, true);
        }
    }
}
