namespace Enshrouded_Server_Manager.Models;
public record AdminButtonState
{
    public bool Enabled { get; set; }
    public bool Visible { get; set; }
    public Color BorderColor { get; set; }
}

public static class AdminButtonStateExtensions
{
    public static AdminButtonState SetVisible(this AdminButtonState button, bool isVisible)
    {
        return button with
        {
            Visible = isVisible
        };
    }

    public static AdminButtonState SetBorderColor(this AdminButtonState button, Color borderColor)
    {
        return button with
        {
            BorderColor = borderColor
        };
    }

    public static AdminButtonState SetEnabled(this AdminButtonState button, bool isEnabled)
    {
        return button with
        {
            Enabled = isEnabled
        };
    }
}
