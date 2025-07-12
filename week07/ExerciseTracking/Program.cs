using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("========================");
        Console.WriteLine();

        // Create a list to hold different types of activities
        List<Activity> activities = new List<Activity>();

        // Create one activity of each type
        Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2022, 11, 3), 30, 12.0);
        Swimming swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);

        // Add activities to the list
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Display summary for each activity using polymorphism
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        Console.WriteLine("Demonstration of polymorphism:");
        Console.WriteLine("The same GetSummary() method call works differently for each activity type!");
    }
}