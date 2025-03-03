class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time that you stood up for someone else or yourself.",
        "Think of a time that you overcame a challenge.",
        "Think of a time that you made a mistake and learned from it.",
        "Think of a time that you sacrificed something for another person.",
        "Think of a time that you helped another person see their worth."
    };


    private List<string> _responsePrompts = new List<string>
    {
        "Why was this experience important to you?",
        "have you ever done something similar before?",
        "How did you feel during this experience?",
        "How did you feel after this experience?",
        "What made this time different from other experiences where you weren't as successful?",
        "What did you learn about yourself from this experience?",
        "How can you use this experience to help you in the future?",
        "What was your favorite part of this experience?",
        "What was the most challenging part of this experience?"
    };
    private List<string> _responses = new List<string>();

    public ReflectingActivity() 
        : base("Reflecting Activity", "This activity will help you reflct on experiences where you've shown strength and resilience, which will help you to recognize and utilize that strength at other points in your life.") 
        { }

    protected override void PerformActivity(TimerUtility timer)
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        while (timer.IsTimeRemaining())
        {
            string responsePrompt = _responsePrompts[random.Next(_responsePrompts.Count)];
            Console.WriteLine($"\n{responsePrompt}");
            Thread.Sleep(4000);
            Console.Write("Write your response: ");
            string response = Console.ReadLine();
            _responses.Add(response);
        }

        Console.WriteLine("\nReflection completed! Here are your responses:");
        Console.WriteLine($"You listed { _responses.Count } things.");
        foreach (string response in _responses)
        {
            Console.WriteLine($"- {response}");
        }
    }
}