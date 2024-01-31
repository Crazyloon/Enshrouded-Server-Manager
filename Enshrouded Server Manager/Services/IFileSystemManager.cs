namespace Enshrouded_Server_Manager.Services;

public interface IFileSystemManager
{
    public void CreateDirectory(string directoryName);
    public void DeleteDirectory(string directoryName);
    public bool RenameDirectory(string oldDirectoryName, string newDirectoryname);
    public bool FileExists(string fileName);
    public void DeleteFile(string fileName);
    public void WriteFile(string fileName, string content);
}