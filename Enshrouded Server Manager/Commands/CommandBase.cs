using System.ComponentModel;

namespace Enshrouded_Server_Manager.Commands;
public abstract class CommandBase : IAdminPanelCommand
{
    private bool _isEnabled;
    private bool _isVisible;
    private Color _borderColor;
    public event PropertyChangedEventHandler PropertyChanged;

    protected CommandBase()
    {
        _isEnabled = true;
    }


    public bool IsEnabled
    {
        get { return _isEnabled; }
        set
        {
            _isEnabled = value;
            OnPropertyChanged("IsEnabled");
        }
    }

    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            OnPropertyChanged("IsVisible");
        }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            OnPropertyChanged("BorderColor");
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public abstract void Execute();
}
