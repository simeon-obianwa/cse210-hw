using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;

    // Initialize the list
    public List<Job> _jobs = new List<Job>();

    // Behavior: Display resume information
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Iterate each job and call its Display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}