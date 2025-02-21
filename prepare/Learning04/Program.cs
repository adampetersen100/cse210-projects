using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Adam", "Calculus");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("James", "Algebra", "Chapter 2.1", "10-21");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Johnny", "American History", "The American Revolution");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}