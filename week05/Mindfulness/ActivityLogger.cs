using System;
using System.Collections.Generic;

public class ActivityLogger
{
    // Private dictionary hides internal tracking by applying encapsulation
    private readonly Dictionary<string, int> _logs = new();

    public void Record(string activityName)
    {
        if (_logs.ContainsKey(activityName))
            _logs[activityName]++;
        else
            _logs[activityName] = 1;
    }

    public void Display()
    {
        if (_logs.Count == 0)
        {
            Console.WriteLine("No activities have been logged yet.");
            return;
        }

        Console.WriteLine("\n========== Mindfulness Log ==========");
        foreach (var kvp in _logs)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} time(s)");
        }
        Console.WriteLine("=====================================");
    }
}