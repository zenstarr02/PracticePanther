using PP.Library.Models;
using PP.Library.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PP.MAUI.ViewModels;

public class TimerViewModel : INotifyPropertyChanged
{
    private IDispatcherTimer timer { get; set; }

    public ICommand StartCommand { get; private set; }
    public ICommand StopCommand { get; private set; }

    public Project Project { get; set; }

    private Stopwatch stopwatch { get; set; }

    public string TimerDisplay
    {
        get
        {
            return string.Format("{0:00}:{1:00}:{2:00}", 
                stopwatch.Elapsed.Hours,
                stopwatch.Elapsed.Minutes,
                stopwatch.Elapsed.Seconds);
        }
    }


    public string ProjectDisplay {  
        
        get
        {
            return Project.ShortName;
        }
    }


    public void ExecuteStart()
    {
        stopwatch.Start();
        timer.Start();
    }

    public void ExecuteStop()
    {
        stopwatch.Stop();
    }

    private void SetupCommands()
    {
        StartCommand = new Command(ExecuteStart);
        StopCommand = new Command(ExecuteStop);
    }
    public TimerViewModel(int projectId)
	{
		Project = ProjectService.Current.Get(projectId)?? new Project();
        stopwatch = new Stopwatch();
        timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = new TimeSpan(0,0,0,1);
        timer.IsRepeating = true;

        timer.Tick += Timer_Tick;
        SetupCommands();
	}

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (timer.IsRunning)
        {
            NotifyPropertyChanged(nameof(TimerDisplay));
        }
    
    }

    public void AddOrUpdate()
    {
        TimeService.Current.AddOrUpdate(GetTimeobj());
    }

    public Time GetTimeobj()
    {
        if(stopwatch.Elapsed.Seconds == 0) 
        {
            return new Time();
        }
        else
        {
            return new Time() { EmployeeId = 1, ProjectId = Project.Id, Date = DateTime.Now, Hours = stopwatch.Elapsed.Seconds / 60 / 60 };
        }

    }


    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
