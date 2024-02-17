using Enshrouded_Server_Manager.Enums;

namespace Enshrouded_Server_Manager.Models;
public class ScheduleRestarts
{
    public bool Enabled { get; set; }
    public bool StartScheduleWithServer { get; set; }
    public RestartFrequency RestartFrequency { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public int RecurrenceInterval { get; set; }
    public DayOfWeek[] DaysOfWeek { get; set; }
}
