using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> exerciseLog = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 03), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 05), 45, 28.5),
            new Swimming(new DateTime(2022, 11, 07), 40, 40)
        };

        foreach (Activity activity in exerciseLog)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}