namespace Enshrouded_Server_Manager.Services;

public interface IFileSystemService
{
    public void CreateDirectory(string directoryName);
    public void DeleteDirectory(string directoryName);
    public bool RenameDirectory(string oldDirectoryName, string newDirectoryname);
    public bool DirectoryExists(string directoryName);
    public bool FileExists(string fileName);
    public void DeleteFile(string fileName);
    public void WriteFile(string fileName, string content);
    public string ReadFile(string fileName);
    public IEnumerable<string> ReadLines(string fileName);
    public void CopyFile(string sourceFileName, string destFileName);
    public void CreateZipFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
    public void ExtractZipToDirectory(string sourceArchiveFileName, string destinationDirectoryName);
}