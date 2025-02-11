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