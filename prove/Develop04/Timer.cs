using System;
using System.Threading;

class TimerUtility
{
    private DateTime _endTime;
    private bool _isRunning;

    public TimerUtility(int durationInSeconds)
    {
        _endTime = DateTime.Now.AddSeconds(durationInSeconds);
        _isRunning = true;
    }

    public bool IsTimeRemaining()
    {
        return DateTime.Now < _endTime;
    }

    public void StartAnimation()
    {
        List<string> animationFrames = new List<string> { "|", "/", "-", "\\" };
        int i = 0;

        while (_isRunning && IsTimeRemaining())
        {
            Console.Write(animationFrames[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i = (i + 1) % animationFrames.Count;
        }
    }

    public void Stop()
    {
        _isRunning = false;
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
