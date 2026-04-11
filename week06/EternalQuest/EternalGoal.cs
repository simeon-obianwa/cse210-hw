using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, int pointsPerEvent) : base(name, pointsPerEvent) { }

    public override int RecordEvent(TimeSpan duration)
    {
        _eventsCompleted++;
        _lastCompletedDate = DateTime.Now;
        _lastDuration = duration;
        _isCompleted = false; 
        return _pointsPerEvent;
    }

    public override string GetDisplayString()
    {
        string dateInfo = _lastCompletedDate.HasValue
            ? $" | Last: {_lastCompletedDate.Value:yyyy-MM-dd} ({_lastDuration.TotalMinutes:F1} min)"
            : "";
        return $"[ ] {_name} (Recorded {_eventsCompleted} times){dateInfo}";
    }
}