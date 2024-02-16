using System.Diagnostics;

namespace Enshrouded_Server_Manager.Services;

// Based on Stack Overflow answer by user "Andrew_STOP_RU_WAR_IN_UA" https://stackoverflow.com/users/4423545/andrew-stop-ru-war-in-ua
// https://stackoverflow.com/questions/6191576/seconds-countdown-timer/54119639#54119639

public class CountDownTimer : IDisposable
{
    // TODO: Add these as dependencies via constructor
    private IFileLogger logger = new FileLogger(new FileSystemService());

    private Stopwatch _stpWatch = new Stopwatch();
    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private TimeSpan _max = TimeSpan.FromMilliseconds(30000);
    private bool _mustStop => (_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) < 0;

    public Action TimeChanged;
    public Action CountDownFinished;
    public string Tag = "";

    public bool IsRunning => timer.Enabled;

    public int StepMs
    {
        get => timer.Interval;
        set => timer.Interval = value;
    }

    public TimeSpan TimeLeft => (_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) > 0 ? TimeSpan.FromMilliseconds(_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) : TimeSpan.FromMilliseconds(0);

    public string TimeLeftStr => TimeLeft.ToString("d'.'hh':'mm':'ss");

    public string TimeLeftMsStr => TimeLeft.ToString(@"mm\:ss\.fff");

    private void TimerTick(object sender, EventArgs e)
    {
        TimeChanged?.Invoke();

        if (_mustStop)
        {
            logger.LogInfo("CountDownTimer: TimerTick: CountDownFinished");
            CountDownFinished?.Invoke();
            _stpWatch.Stop();
            timer.Enabled = false;
        }
    }

    public CountDownTimer(int min, int sec)
    {
        logger.LogInfo("CountDownTimer: Created");
        SetTime(min, sec);
        Init();
    }

    public CountDownTimer(TimeSpan ts)
    {
        logger.LogInfo("CountDownTimer: Created");
        SetTime(ts);
        Init();
    }

    public CountDownTimer()
    {
        logger.LogInfo("CountDownTimer: Created");
        Init();
    }

    private void Init()
    {
        StepMs = 1000;
        timer.Tick += new EventHandler(TimerTick);
    }

    public void SetTime(TimeSpan ts)
    {
        _max = ts;
        TimeChanged?.Invoke();
    }

    public void SetTime(int min, int sec = 0) => SetTime(TimeSpan.FromSeconds(min * 60 + sec));

    public void Start()
    {
        timer.Start();
        _stpWatch.Start();
    }

    public void Pause()
    {
        timer.Stop();
        _stpWatch.Stop();
    }

    public void EndTimer()
    {
        logger.LogInfo("CountDownTimer: EndTimer");

        timer.Stop();
        _stpWatch.Stop();

        _stpWatch.Reset();
        _max = TimeSpan.FromMilliseconds(0);

        timer.Enabled = false;
        TimeChanged?.Invoke();

        Dispose();
    }

    public void Dispose() => timer.Dispose();
}
