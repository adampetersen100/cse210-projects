using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Apr 2024", 30, 3.0),
            new Cycling("03 Apr 2024", 45, 15.0),
            new Swimming("03 Apr 2024", 40, 32)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
