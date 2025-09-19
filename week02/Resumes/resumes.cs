using System;
using System.Collections.Generic;

public class Resume
{
    // Attributes
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Method to display the entire resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}