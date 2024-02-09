namespace Enshrouded_Server_Manager.Models;
public record AdminButtonState
{
    public bool Enabled { get; set; }
    public bool Visible { get; set; }
    public Color BorderColor { get; set; }
}
