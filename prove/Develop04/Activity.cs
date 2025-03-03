using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    private string _activityName;
    private string _activityDescription;
    private int _duration;
    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
        _duration = 0;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_activityName}: {_activityDescription}");
        Console.Write("Enter duration in seconds: ");
        _duration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        Thread.Sleep(2000);

        TimerUtility timer = new TimerUtility(_duration);

        PerformActivity(timer);

        Console.WriteLine($"\n{_activityName} completed.");
    }

    protected virtual void PerformActivity(TimerUtility timer) { }
}
