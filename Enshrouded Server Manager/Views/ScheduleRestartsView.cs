using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.UI;

namespace Enshrouded_Server_Manager.Views;
public partial class ScheduleRestartsView : UserControl, IScheduleRestartsView
{
    private RestartFrequency _selectedFrequency;
    private DayOfWeek[] _selectedDays;

    public ScheduleRestartsView()
    {
        InitializeComponent();

        radOneTime.Tag = RestartFrequency.OneTime;
        radHourly.Tag = RestartFrequency.Hourly;
        radDaily.Tag = RestartFrequency.Daily;
        radWeekly.Tag = RestartFrequency.Weekly;
        radMonthly.Tag = RestartFrequency.Monthly;

        chkSunday.Tag = DayOfWeek.Sunday;
        chkMonday.Tag = DayOfWeek.Monday;
        chkTuesday.Tag = DayOfWeek.Tuesday;
        chkWednesday.Tag = DayOfWeek.Wednesday;
        chkThursday.Tag = DayOfWeek.Thursday;
        chkFriday.Tag = DayOfWeek.Friday;
        chkSaturday.Tag = DayOfWeek.Saturday;
    }

    public event EventHandler SaveSettings
    {
        add { btnApplySettings.Click += value; }
        remove { btnApplySettings.Click -= value; }
    }

    public event EventHandler ClearAll
    {
        add { btnClearAll.Click += value; }
        remove { btnClearAll.Click -= value; }
    }

    public event EventHandler RestartFrequencyChanged
    {
        add
        {
            foreach (var radio in this.Controls.OfType<RadioButton>())
            {
                radio.CheckedChanged += value;
            }
        }
        remove
        {
            foreach (var radio in this.Controls.OfType<RadioButton>())
            {
                radio.CheckedChanged -= value;
            }
        }
    }

    public event EventHandler StartDateChanged
    {
        add { dtpStartDate.ValueChanged += value; }
        remove { dtpStartDate.ValueChanged -= value; }
    }

    public event EventHandler StartTimeChanged
    {
        add { dtpStartTime.ValueChanged += value; }
        remove { dtpStartTime.ValueChanged -= value; }
    }

    public bool IsScheduledRestartEnabled
    {
        get => chkEnableScheduledRestarts.Checked;
        set => chkEnableScheduledRestarts.Checked = value;
    }

    public bool IsScheduledWithServerStart
    {
        get => chkStartWithServer.Checked;
        set => chkStartWithServer.Checked = value;
    }

    public string TimeLeft
    {
        get => lblTimeLeft.Text;
        set => lblTimeLeft.Text = value;
    }

    public RestartFrequency RestartFrequency
    {
        get
        {
            var checkedBtn = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedBtn is null)
            {
                return RestartFrequency.None;
            }
            return (RestartFrequency)checkedBtn.Tag;
        }
        set
        {
            foreach (var radio in this.Controls.OfType<RadioButton>())
            {
                radio.Checked = false;
            }

            var selected = this.Controls.OfType<RadioButton>().FirstOrDefault(r => (RestartFrequency)r.Tag == value);
            if (selected is not null)
            {
                selected.Checked = true;
            }
        }
    }

    public DayOfWeek[] DaysOfWeek
    {
        get
        {
            return this.Controls.OfType<CheckBox>().Where(c => c.Checked && c.Tag is not null).Select(c => (DayOfWeek)c.Tag).ToArray();
        }
        set
        {
            foreach (var day in this.Controls.OfType<CheckBox>().Where(c => c.Tag is not null))
            {
                day.Checked = false;
            }

            foreach (var day in value)
            {
                this.Controls.OfType<CheckBox>().Where(c => c.Tag is not null).FirstOrDefault(c => (DayOfWeek)c.Tag == day).Checked = true;
            }
        }
    }

    public DateOnly StartDate
    {
        get => new DateOnly(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day);
        set => dtpStartDate.Value = new DateTime(value.Year, value.Month, value.Day);
    }

    public TimeOnly StartTime
    {
        get => new TimeOnly(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
        set => dtpStartTime.Value = new DateTime(2000, 1, 1, value.Hour, value.Minute, value.Second);
    }

    public int RecurrenceInterval
    {
        get => (int)nudRecur.Value;
        set => nudRecur.Value = value;
    }
    public string RecurrenceIntervalUnit
    {
        get => lblRecurUnit.Text;
        set => lblRecurUnit.Text = value;
    }

    public void AnimateSaveButton()
    {
        Interactions.AnimateSaveChangesButton(btnApplySettings, btnApplySettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnApplySettings_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }
}
