using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int pointsPerEvent, int targetCount, int bonusPoints) : base(name, pointsPerEvent)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public int GetTargetCount() => _targetCount;
    public int GetBonusPoints() => _bonusPoints;

    public override int RecordEvent(TimeSpan duration)
    {
        _eventsCompleted++;
        _lastCompletedDate = DateTime.Now;
        _lastDuration = duration;

        if (_eventsCompleted >= _targetCount)
        {
            _isCompleted = true;
            return _pointsPerEvent + _bonusPoints; 
        }
        return _pointsPerEvent;
    }

    public override string GetDisplayString()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        string dateInfo = _lastCompletedDate.HasValue
            ? $" | Last: {_lastCompletedDate.Value:yyyy-MM-dd} ({_lastDuration.TotalMinutes:F1} min)"
            : "";
        return $"{status} {_name} ({_eventsCompleted}/{_targetCount}){dateInfo}";
    }
}