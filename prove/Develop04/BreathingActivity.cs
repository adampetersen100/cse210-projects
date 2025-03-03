using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
              "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    { }

    protected override void PerformActivity(TimerUtility timer)
    {
        while (timer.IsTimeRemaining())
        {
            Console.WriteLine("\rBreathe in...");
            CountdownAnimation(5);
            
            Console.WriteLine("\rHold...");
            CountdownAnimation(6);

            Console.WriteLine("\rBreathe out...");
            CountdownAnimation(5);

            Console.WriteLine("\rHold...");
            CountdownAnimation(6);
            Console.WriteLine();
        }
    }

    private void CountdownAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}  "); // Overwrite previous number
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r"); // Clear last number
    }
}
