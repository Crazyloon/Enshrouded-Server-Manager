using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Enshrouded_Server_Manager.Models;
public class ServerProfile : INotifyPropertyChanged
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    public AutoBackup AutoBackup { get; set; }
    public ScheduleRestarts ScheduleRestarts { get; set; }

    public RestoreBackup RestoreBackup { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
