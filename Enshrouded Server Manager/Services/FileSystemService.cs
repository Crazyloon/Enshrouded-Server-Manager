using System.IO.Compression;

namespace Enshrouded_Server_Manager.Services;

public class FileSystemService : IFileSystemService
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

    public void MoveDirectory(string oldDirectoryName, string newDirectoryName)
    {
        Directory.Move(oldDirectoryName, newDirectoryName);
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

    public bool DirectoryExists(string directoryName)
    {
        return Directory.Exists(directoryName);
    }

    public bool FileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    public void DeleteFile(string fileName)
    {
        File.Delete(fileName);
    }

    public void WriteFile(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }

    public string ReadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public void CopyFile(string sourceFileName, string destFileName)
    {
        File.Copy(sourceFileName, destFileName);
    }

    public void CreateZipFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
    {
        ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
    }

    public void ExtractZipToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
    {
        ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
    }
}