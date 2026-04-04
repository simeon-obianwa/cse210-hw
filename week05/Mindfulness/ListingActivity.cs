using System;
using System.Diagnostics;

public class ListingActivity : MindfulnessActivity
{
    private readonly string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private readonly Random _random = new();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void PerformActivity()
    {
        Console.WriteLine($"\n{_prompts[_random.Next(_prompts.Length)]}");
        Console.WriteLine("Take a moment to consider this prompt...");
        PauseWithAnimation(3, AnimationType.Countdown);

        Console.WriteLine("\nBegin listing items now. (Press Enter after each. Press Enter with empty input to stop.)");

        Stopwatch sw = Stopwatch.StartNew();
        int itemCount = 0;

        // Used Console.ReadLine() blocks execution to ensure time is checked before/after input.
        while (sw.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;
            
            itemCount++;
        }

        Console.WriteLine($"\nYou listed {itemCount} item(s).");
    }
}