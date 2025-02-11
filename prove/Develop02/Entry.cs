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