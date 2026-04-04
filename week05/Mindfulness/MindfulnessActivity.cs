using System;
using System.Diagnostics;
using System.Threading;

// Demonstrating abstraction, the base class defines a contract and shared program blueprint
public abstract class MindfulnessActivity
{
    // Demonstrating encapsulation, making the private fields to protect internal state
    private readonly string _name;
    private readonly string _description;

    // Demonstrating inheriting attributes, the protected property allows derived classes to read
    // the duration while preventing external modification of the program.
    protected int Duration { get; private set; }

    protected MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Demonstrating inheriting behaviors 
    public void Run()
    {
        DisplayStartSequence();
        PerformActivity(); 
        DisplayEndSequence();
    }

    // Making behaviors available to all derived classes
    protected void DisplayStartSequence()
    {
        Console.WriteLine($"\n=== {_name} ===");
        Console.WriteLine(_description);
        PromptDuration();
        Console.WriteLine("\nPlease prepare to begin...");
        PauseWithAnimation(3, AnimationType.Dots);
    }

    protected void DisplayEndSequence()
    {
        Console.WriteLine("\nExcellent work! You did a great job.");
        PauseWithAnimation(2, AnimationType.Dots);
        Console.WriteLine($"You successfully completed: {_name}");
        Console.WriteLine($"Total duration: {Duration} seconds");
        PauseWithAnimation(3, AnimationType.Dots);
    }

    protected void PromptDuration()
    {
        while (true)
        {
            Console.Write("How many seconds would you like this activity to last? ");
            if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0)
            {
                Duration = seconds;
                return;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    protected enum AnimationType { Dots, Countdown, Spinner }

    protected void PauseWithAnimation(int seconds, AnimationType type)
    {
        if (type == AnimationType.Dots)
        {
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine();
        }
        else if (type == AnimationType.Countdown)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\r {i:D2}  ");
                Thread.Sleep(1000);
            }
            Console.Write("\r     "); // Clear line
            Console.WriteLine();
        }
        else if (type == AnimationType.Spinner)
        {
            char[] spinner = { '|', '/', '-', '\\' };
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                int index = (int)(sw.Elapsed.TotalMilliseconds / 250) % spinner.Length;
                Console.Write($"\r {spinner[index]}  ");
                Thread.Sleep(100);
            }
            Console.Write("\r     "); // Clear line
            Console.WriteLine();
        }
    }

    protected abstract void PerformActivity();
}