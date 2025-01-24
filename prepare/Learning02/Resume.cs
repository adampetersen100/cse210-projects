using System;

public class Resume()
{
    public string _name = "";
    public List<Job> _jobs = [];

    public void DisplayResumeInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs: ");
        
        foreach (Job job in _jobs)
        {
            job.DisplayJobInfo();
        }
    }
}