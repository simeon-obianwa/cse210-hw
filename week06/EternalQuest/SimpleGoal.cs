using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int pointsPerEvent) : base(name, pointsPerEvent) { }

    public override int RecordEvent(TimeSpan duration)
    {
        if (!_isCompleted)
        {
            return base.RecordEvent(duration);
        }
        return 0; 
    }

    public override string GetDisplayString()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        string dateInfo = _lastCompletedDate.HasValue
            ? $" | Completed: {_lastCompletedDate.Value:yyyy-MM-dd} ({_lastDuration.TotalMinutes:F1} min)"
            : "";
        return $"{status} {_name}{dateInfo}";
    }
}