
using System;
using System.Collections.Generic;

// The main program class to demonstrate the functionality.
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold all activity objects.
        List<Activity> activities = new List<Activity>();

        // Create an instance of each activity type and add it to the list.
        activities.Add(new Running(new DateTime(2023, 11, 03), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2023, 11, 03), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2023, 11, 04), 20, 40));

        // Iterate through the list and display the summary for each activity.
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}