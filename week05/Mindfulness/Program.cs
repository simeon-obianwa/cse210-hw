// Showing Creativity: I included ActivityLogger to track session counts in memory and to display Activity History when option 4 is selected.

using System;

class Program
{
    static void Main()
    {
        ActivityLogger logger = new ActivityLogger();
        
        // I applied polymorphism to help store derived objects in base class array
        MindfulnessActivity[] activities = new MindfulnessActivity[]
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        string[] activityNames = { "Breathing Activity", "Reflection Activity", "Listing Activity" };

        while (true)
        {
            Console.WriteLine("\n╔════════════════════════════════╗");
            Console.WriteLine("║  MINDFULNESS MENU OPTIONS      ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║ 1) Start Breathing Activity    ║");
            Console.WriteLine("║ 2) Start Reflection Activity   ║");
            Console.WriteLine("║ 3) Start Listing Activity      ║");
            Console.WriteLine("║ 4) View Activity History       ║");
            Console.WriteLine("║ 5) Exit                        ║");
            Console.WriteLine("╚════════════════════════════════╝");

            Console.Write("\nSelect a choice from the menu (1-5): ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int option) && option >= 1 && option <= 3)
            {
                activities[option - 1].Run();
                logger.Record(activityNames[option - 1]);
            }
            else if (option == 4)
            {
                logger.Display();
            }
            else if (option == 5)
            {
                Console.WriteLine("Thank you for practicing mindfulness. Take care!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
        }
    }
}