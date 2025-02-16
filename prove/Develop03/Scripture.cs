using System.Collections.Concurrent;

class Scripture 
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
  
    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(word => word.ToString())));
    }

public void HideRandomWords(int count)
{
    Random rand = new Random();
    var visibleWords = _words.Where(w => !w.IsHidden).ToList();

    if (visibleWords.Count == 0) return;

    foreach (var word in visibleWords.OrderBy(x => rand.Next()).Take(count))
    {
        word.Hide();
    }
}

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}