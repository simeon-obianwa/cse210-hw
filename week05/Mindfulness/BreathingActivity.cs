using System;
using System.Diagnostics;

// Demonstrating inheritance hierarchy to extends MindfulnessActivity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    // To overrides abstract method to implement specific program behavior
    protected override void PerformActivity()
    {
        Stopwatch sw = Stopwatch.StartNew();
        bool inhaling = true;
        int pauseSeconds = 4;

        // Demonstrating inheriting attributes by using 'Duration' from base class
        while (sw.Elapsed.TotalSeconds < Duration)
        {
            string message = inhaling ? "Breathe in..." : "Breathe out...";
            Console.WriteLine($"\n{message}");
            
            // Demonstrating inheriting behaviors by using base class animation method
            PauseWithAnimation(pauseSeconds, AnimationType.Countdown);
            inhaling = !inhaling;
        }
    }
}