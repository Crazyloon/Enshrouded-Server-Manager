namespace Enshrouded_Server_Manager.Services;

public class FileSystemManager : IFileSystemManager
{
    public void CreateDirectory(string directoryName)
    {
        Directory.CreateDirectory(directoryName);
    }

    public void DeleteDirectory(string directoryName)
    {
        if (Directory.Exists(directoryName))
        {
            Directory.Delete(directoryName, true);
        }
    }

    public bool RenameDirectory(string oldDirectoryName, string newDirectoryName)
    {
        if (Directory.Exists(oldDirectoryName))
        {
            Directory.Move(oldDirectoryName, newDirectoryName);
            return true;
        }
        return false;
    }

    public bool FileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    public void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
    }

    public void WriteFile(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }
}