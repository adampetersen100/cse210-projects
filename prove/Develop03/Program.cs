using System;

class Program
{
    static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (!scripture.IsFullyHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words...");
            Console.ReadLine();
            scripture.HideRandomWords(3);
        }

        Console.WriteLine("All words are hidden, Good job!");
    }
}
