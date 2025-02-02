using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;
        
         while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.CreateEntry();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.Save(saveFile);
                    break;
                case "4":
                Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.Load(loadFile);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class Entry
{
    private DateTime _date;
    private string _text;
    private string _prompt;

    public Entry(string prompt, string text)
    {
        _date = DateTime.Now;
        _prompt = prompt;
        _text = text;
    }

    public string GetFormattedEntry()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_text}\n";
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public override string ToString()
    {
        return $"{_date}|{_prompt}|{_text}";
    }

    public static Entry FromString(string entryString)
    {
        string[] parts = entryString.Split('|');
        if (parts.Length == 3 && DateTime.TryParse(parts[0], out DateTime entryDate))
        {
            return new Entry(parts[1], parts[2]) { _date = entryDate };
        }
        return null;
    }
}
class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string _filePath;
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public void CreateEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        if (prompt == null)
        {
            Console.WriteLine("No more new prompts available.");
            return;
        }

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        _entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry saved!\n");
    }
    public void Save(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}.\n");
    }


    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.GetFormattedEntry());
        }

        Console.WriteLine("Options:");
        Console.WriteLine("1. Filter by date");
        Console.WriteLine("2. Return to menu");
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();

        if (option == "1")
        {
            Console.Write("Enter a date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                FilterEntriesByDate(date);
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
    }

      public void FilterEntriesByDate(DateTime date)
    {
        var filteredEntries = _entries.Where(e => e.GetDate().Date == date.Date).ToList();

        if (filteredEntries.Count == 0)
        {
            Console.WriteLine($"No entries found for {date:yyyy-MM-dd}.");
        }
        else
        {
            Console.WriteLine($"\nEntries for {date:yyyy-MM-dd}:");
            foreach (var entry in filteredEntries)
            {
                Console.WriteLine(entry.GetFormattedEntry());
            }
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}.\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}.\n");
    }
}

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