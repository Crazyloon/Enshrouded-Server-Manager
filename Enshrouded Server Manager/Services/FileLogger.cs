namespace Enshrouded_Server_Manager.Services;
public class FileLogger : IFileLoggerService
{
    private readonly IFileSystemService _fileSystemService;
    private int MB_5 = (1024 * 1024) * 5;
    private int TWO_WEEKS = 14;

    public FileLogger(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;

        ESMLogPath = Path.Join(Constants.Paths.GAME_SERVER_LOGS_DIRECTORY, "esm-logs");

        if (!_fileSystemService.DirectoryExists(ESMLogPath))
        {
            _fileSystemService.CreateDirectory(ESMLogPath);
        }
    }

    private string ESMLogPath { get; set; }

    public void LogError(string errorMessage)
    {
        string error = $"[{DateTime.Now.ToString("s")}] {errorMessage}\n";
        string fileName = GetLogFileName("error");

        try
        {
            _fileSystemService.AppendAllText(fileName, error);
        }
        catch (Exception)
        {

        }
    }

    public void LogInfo(string infoMessage)
    {
        string log = $"[{DateTime.Now.ToString("s")}] {infoMessage}\n";
        string fileName = GetLogFileName("info");

        try
        {
            _fileSystemService.AppendAllText(fileName, log);
        }
        catch (Exception)
        {

        }
    }

    public void LogWarning(string warningMessage)
    {
        string warning = $"[{DateTime.Now.ToString("s")}] {warningMessage}\n";
        string fileName = GetLogFileName("warning");

        try
        {
            _fileSystemService.AppendAllText(fileName, warning);
        }
        catch (Exception)
        {

        }
    }

    private string GetLogFileName(string logType)
    {
        string fileName = Path.Join(ESMLogPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}-{logType}.txt");
        if (File.Exists(fileName))
        {
            long fileSize = _fileSystemService.GetFileSize(fileName);

            var i = 1;
            while (fileSize > MB_5)
            {
                fileName = Path.Join(ESMLogPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}-{logType}{i}.txt");
                if (!File.Exists(fileName))
                {
                    return fileName;
                }
                fileSize = _fileSystemService.GetFileSize(fileName);

                i = i + 1;
            }
        }

        return fileName;
    }

    private void DeleteOldLogs()
    {
        var files = _fileSystemService.GetFiles(ESMLogPath);
        foreach (var file in files)
        {
            if (file.CreationTime < DateTime.Now.AddDays(-TWO_WEEKS))
            {
                _fileSystemService.DeleteFile(file.FullName);
            }
        }
    }
}
