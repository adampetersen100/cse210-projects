using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");
            userNumber = int.Parse(Console.ReadLine());
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }

        }

        int sum = 0;
        foreach (int value in numbers)
        {
            sum += value;
        }
        Console.WriteLine($"The sum is: {sum}");

        int numberCount = numbers.Count();
        float average = sum / numberCount;
        Console.WriteLine($"The average is: {average}");

        int highestNumber = 0;

        foreach (int i in numbers)
        {
            if (i > highestNumber)
            {
                highestNumber = i;
            }
        }
        Console.WriteLine($"The largest number is: {highestNumber}");
    }
}