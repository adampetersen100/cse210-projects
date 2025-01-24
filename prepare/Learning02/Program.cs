using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";

        Job company1 = new Job();
        company1._company = "Microsoft";

        Job company2 = new Job();
        company2._company = "Apple";

        Job start1 = new Job();
        start1._startYear = 1999;

        Job end1 = new Job();
        end1._endYear = 2023;

        Console.WriteLine(job1._jobTitle);
        Console.WriteLine(company1._company);
        Console.WriteLine(company2._company);
    }
}