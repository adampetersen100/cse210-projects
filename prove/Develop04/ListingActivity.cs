using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _responses = new List<string>();

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void PerformActivity(TimerUtility timer)
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        
        Console.WriteLine($"\n{prompt}");
        Console.Write("You have a few seconds to think about your responses... ");
        timer.Countdown(5);

        Console.WriteLine("\nStart listing your responses. Type as many as you can:");

        while (timer.IsTimeRemaining())
        {
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }

        Console.WriteLine("\nListing completed!");
        Console.WriteLine($"You listed {_responses.Count} items.");
        foreach (string response in _responses)
        {
            Console.WriteLine($"- {response}");
        }
    }
}
