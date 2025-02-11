class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What did you do to be 1% better today?",
        "What was a higlight of the day?",
        "What are three things you are grateful for today?",
        "What is something that has been on your mind lately?",
        "If you had unlimited time and resources, what creative project would you start?",
        "Who is someone you miss, and why?",
        "Where do you want to be in 5 years?",
        "What is one skill you want to improve?",
        "What sounds really fun to do right now?",
        "Describe your feelings from today in one word, and explain why you chose that word."
    };
    
    private HashSet<string> _usedPrompts = new HashSet<string>();

    public string GetRandomPrompt()
    {
        var availablePrompts = _prompts.Except(_usedPrompts).ToList();
        if (availablePrompts.Count == 0)
        {
            return null; // No more unique prompts
        }

        Random rand = new Random();
        string prompt = availablePrompts[rand.Next(availablePrompts.Count)];
        _usedPrompts.Add(prompt);
        return prompt;
    }
}