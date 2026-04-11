using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public int GetTotalScore() => _totalScore;
    public int GetGoalCount() => _goals.Count;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ListGoals()
    {
        Console.WriteLine("\n--- Your Goals ---");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals set yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalIndex - 1];
        if (selectedGoal.GetIsCompleted())
        {
            Console.WriteLine(" This goal is already completed.");
            return;
        }

        Console.Write("Enter time spent on this goal (in minutes, or 0 to skip): ");
        if (!double.TryParse(Console.ReadLine(), out double minutes) || minutes < 0)
        {
            Console.WriteLine(" Invalid input. Assuming 0 minutes.");
            minutes = 0;
        }

        TimeSpan duration = TimeSpan.FromMinutes(minutes);
        int points = selectedGoal.RecordEvent(duration);
        _totalScore += points;

        Console.WriteLine($" Congratulations! You earned {points} points.");
        if (selectedGoal.GetIsCompleted())
        {
            Console.WriteLine(" Goal completed!");
        }
        Console.WriteLine($"Current Score: {_totalScore}");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_totalScore);
            foreach (Goal goal in _goals)
            {
                string goalType = goal.GetType().Name;
                string dateStr = goal.GetLastCompletedDate()?.ToString("o") ?? "";
                double durationSec = goal.GetLastDuration().TotalSeconds;

                writer.WriteLine($"{goalType}|{goal.GetName()}|{goal.GetPointsPerEvent()}|" +
                    $"{(goal is ChecklistGoal cg ? cg.GetTargetCount() : 0)}|" +
                    $"{(goal is ChecklistGoal cg2 ? cg2.GetBonusPoints() : 0)}|" +
                    $"{goal.GetEventsCompleted()}|{goal.GetIsCompleted()}|{dateStr}|{durationSec}");
            }
        }
        Console.WriteLine($" Goals and score saved to {fileName}.");
    }

    public void LoadGoals(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine(" No save file found.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string scoreLine = reader.ReadLine();
            if (int.TryParse(scoreLine, out int score)) _totalScore = score;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 9) continue;

                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);
                int target = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int events = int.Parse(parts[5]);
                bool completed = bool.Parse(parts[6]);
                
                DateTime? lastDate = null;
                if (!string.IsNullOrEmpty(parts[7]))
                {
                    if (DateTime.TryParse(parts[7], out DateTime parsedDate)) lastDate = parsedDate;
                }

                TimeSpan lastDuration = TimeSpan.FromSeconds(double.Parse(parts[8]));

                Goal newGoal = CreateGoalFromData(type, name, points, target, bonus);
                if (newGoal != null)
                {
                    newGoal.LoadState(events, completed, lastDate, lastDuration);
                    _goals.Add(newGoal);
                }
            }
        }
        Console.WriteLine($" Goals and score loaded from {fileName}.");
    }

    private Goal CreateGoalFromData(string type, string name, int points, int target, int bonus) => type switch
    {
        "SimpleGoal" => new SimpleGoal(name, points),
        "EternalGoal" => new EternalGoal(name, points),
        "ChecklistGoal" => new ChecklistGoal(name, points, target, bonus),
        _ => null
    };
}