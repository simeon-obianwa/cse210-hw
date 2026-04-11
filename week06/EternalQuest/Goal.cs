using System;

public abstract class Goal
{
    // I applied encapsulation to protected fields for derived class access
    protected string _name;
    protected int _pointsPerEvent;
    protected int _eventsCompleted;
    protected bool _isCompleted;
    protected DateTime? _lastCompletedDate;
    protected TimeSpan _lastDuration;

    public Goal(string name, int pointsPerEvent)
    {
        _name = name;
        _pointsPerEvent = pointsPerEvent;
        _eventsCompleted = 0;
        _isCompleted = false;
        _lastCompletedDate = null;
        _lastDuration = TimeSpan.Zero;
    }

    // Public accessors
    public string GetName() => _name;
    public int GetPointsPerEvent() => _pointsPerEvent;
    public int GetEventsCompleted() => _eventsCompleted;
    public bool GetIsCompleted() => _isCompleted;
    public DateTime? GetLastCompletedDate() => _lastCompletedDate;
    public TimeSpan GetLastDuration() => _lastDuration;

    // I applied virtual method for polymorphic behavior
    public virtual int RecordEvent(TimeSpan duration)
    {
        _eventsCompleted++;
        _lastCompletedDate = DateTime.Now;
        _lastDuration = duration;
        _isCompleted = true;
        return _pointsPerEvent;
    }

    // I applied virtual method for polymorphic display
    public virtual string GetDisplayString()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        string dateInfo = _lastCompletedDate.HasValue
            ? $" | Last: {_lastCompletedDate.Value:yyyy-MM-dd HH:mm} ({_lastDuration.TotalMinutes:F1} min)"
            : "";
        return $"{status} {_name} ({_pointsPerEvent} pts){dateInfo}";
    }

    // Applied during loading to restore state
    public void LoadState(int eventsCompleted, bool isCompleted, DateTime? lastDate, TimeSpan lastDuration)
    {
        _eventsCompleted = eventsCompleted;
        _isCompleted = isCompleted;
        _lastCompletedDate = lastDate;
        _lastDuration = lastDuration;
    }
}