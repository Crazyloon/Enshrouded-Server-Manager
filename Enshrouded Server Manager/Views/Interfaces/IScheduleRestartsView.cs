using Enshrouded_Server_Manager.Enums;

namespace Enshrouded_Server_Manager.Views;

public interface IScheduleRestartsView
{
    event EventHandler SaveSettings;
    event EventHandler ClearAll;
    event EventHandler RestartFrequencyChanged;
    event EventHandler StartDateChanged;
    event EventHandler StartTimeChanged;

    RestartFrequency RestartFrequency { get; set; }
    DateOnly StartDate { get; set; }
    TimeOnly StartTime { get; set; }
    int RecurrenceInterval { get; set; }
    DayOfWeek[] DaysOfWeek { get; set; }
    string RecurrenceIntervalUnit { get; set; }
}