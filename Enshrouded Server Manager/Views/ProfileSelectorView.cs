using Enshrouded_Server_Manager.Models;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views;
public partial class ProfileSelectorView : UserControl, IProfileSelectorView
{
    public ProfileSelectorView()
    {
        InitializeComponent();
        cbxProfileSelectionComboBox.SelectedIndexChanged += (sender, args) => SelectedProfileChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler AddProfileButtonClicked
    {
        add => btnAddNewProfile.Click += value;
        remove => btnAddNewProfile.Click -= value;
    }

    public event EventHandler DeleteProfileButtonClicked
    {
        add => btnDeleteProfile.Click += value;
        remove => btnDeleteProfile.Click -= value;
    }

    public event EventHandler RenameProfileButtonClicked
    {
        add => btnRenameProfile.Click += value;
        remove => btnRenameProfile.Click -= value;
    }

    public string RenameButtonText
    {
        get => btnRenameProfile.Text;
        set => btnRenameProfile.Text = value;
    }

    public string TimeLeft
    {
        get => lblTimeLeft.Text;
        set => lblTimeLeft.Text = value;
    }

    public bool TimeLeftVisible
    {
        get => lblTimeLeft.Visible;
        set => lblTimeLeft.Visible = value;
    }

    public event EventHandler SelectedProfileChanged;
    public ServerProfile SelectedProfile => (ServerProfile)cbxProfileSelectionComboBox.SelectedItem;

    public void SetProfiles(BindingList<ServerProfile> profiles)
    {
        cbxProfileSelectionComboBox.DataSource = profiles;
        cbxProfileSelectionComboBox.DisplayMember = Constants.PropertyName.NAME;
        cbxProfileSelectionComboBox.SelectedIndex = 0;
    }
}
