using System;
using System.Reflection.Metadata;
using System.Security.Authentication;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage " );
        string gradePercent = Console.ReadLine();
        int percent = int.Parse(gradePercent);

        string letter = "";
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int remainder = percent % 10;
        string sign = "";
        if (remainder >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (remainder < 3 && percent !=100 && letter != "F")
        {
            sign = "-";
        }

        if (letter == "A" || letter == "F")
        {
            Console.WriteLine($"You got an {letter}{sign}");
        }   
        else
        {
            Console.WriteLine($"You got a {letter}{sign}");
        }

        if (percent >= 70)
        {
            Console.Write("Congratulations! You passed!");
        }
        else
        {
            Console.Write("You didn't pass this time, but you will next time around!");
        }

    }
}