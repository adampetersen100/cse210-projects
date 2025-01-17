using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 101);
        int guess = -1;
        string userContinue = "yes";
        while (userContinue == "yes")
        {
            while (guess != randomNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess > randomNumber)
                {
                    Console.WriteLine("Guess lower!");
                }
                else
                {
                    Console.WriteLine("Guess higher!");
                }
            }
            Console.WriteLine($"You got it! The number was {randomNumber}");
            userContinue = Console.ReadLine();
        }
        Console.WriteLine("Thanks for playing!");
    }
}