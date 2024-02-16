namespace Enshrouded_Server_Manager.Services;

public interface IFileSystemService
{
    void CreateDirectory(string directoryName);
    void DeleteDirectory(string directoryName);
    void MoveDirectory(string oldDirectoryName, string newDirectoryName);
    bool RenameDirectory(string oldDirectoryName, string newDirectoryname);
    bool DirectoryExists(string directoryName);
    bool FileExists(string fileName);
    long GetFileSize(string fileName);
    void DeleteFile(string fileName);
    void WriteFile(string fileName, string content);
    void AppendAllText(string fileName, string content);
    string ReadFile(string fileName);
    IEnumerable<string> ReadLines(string fileName);
    void CopyFile(string sourceFileName, string destFileName);
    void CopyFile(string sourceFileName, string destFileName, bool overwrite);
    void CreateZipFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
    void ExtractZipToDirectory(string sourceArchiveFileName, string destinationDirectoryName);
    void ExtractZipToDirectory(string sourceArchiveFileName, string destinationDirectoryName, bool overwrite);
}