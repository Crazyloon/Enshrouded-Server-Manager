namespace Enshrouded_Server_Manager.Views;
public interface IMainFormView
{
    event EventHandler ViewCreditsButtonClicked;
    string CurrentVersionText { get; set; }
}
