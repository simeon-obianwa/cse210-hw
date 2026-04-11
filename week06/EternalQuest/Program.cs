// Creativity - I added a program that will record the time duration and date it took for all the activities to be completed at exit. 
using System;
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine($" Eternal Quest Program- Your Current Score: {manager.GetTotalScore()}");
            Console.WriteLine("\n Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("\nSelect a choice from the menu option (1-6): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoalMenu(manager); break;
                case "2": manager.ListGoals(); Pause(); break;
                case "3": SaveMenu(manager); break;
                case "4": LoadMenu(manager); break;
                case "5": RecordEventMenu(manager); break;
                case "6": isRunning = false; break;
                default: Console.WriteLine(" Invalid option."); Pause(); break;
            }
        }
        Console.WriteLine("\n Thank you for using Eternal Quest! Keep pressing forward.");
    }

    static void CreateGoalMenu(GoalManager manager)
    {
        Console.WriteLine("\n --- Create New Goal ---");
        Console.WriteLine("1. Simple Goal ");
        Console.WriteLine("2. Eternal Goal ");
        Console.WriteLine("3. Checklist Goal ");
        Console.Write("Choose goal type (1-3): ");

        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points per event: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (type)
        {
            case "1": newGoal = new SimpleGoal(name, points); break;
            case "2": newGoal = new EternalGoal(name, points); break;
            case "3":
                Console.Write("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, points, target, bonus);
                break;
            default: Console.WriteLine(" Invalid type."); Pause(); return;
        }

        manager.AddGoal(newGoal);
        Console.WriteLine($" Goal '{name}' added successfully!");
        Pause();
    }

    static void RecordEventMenu(GoalManager manager)
    {
        manager.ListGoals();
        if (manager.GetGoalCount() == 0) { Pause(); return; }

        Console.Write("\nSelect goal number to record event: ");
        if (int.TryParse(Console.ReadLine(), out int choice)) manager.RecordEvent(choice);
        else Console.WriteLine(" Please enter a valid number.");
        Pause();
    }

    static void SaveMenu(GoalManager manager)
    {
        Console.Write("Enter filename to save (e.g., quest_save.txt): ");
        string fileName = Console.ReadLine();
        manager.SaveGoals(fileName);
        Pause();
    }

    static void LoadMenu(GoalManager manager)
    {
        Console.Write("Enter filename to load: ");
        string fileName = Console.ReadLine();
        manager.LoadGoals(fileName);
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}