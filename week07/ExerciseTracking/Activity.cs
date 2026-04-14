using System;

public abstract class Activity
{
    private DateTime _activityDate;
    protected int _durationMinutes;

    public Activity(DateTime activityDate, int durationMinutes)
    {
        _activityDate = activityDate;
        _durationMinutes = durationMinutes;
    }

    // I applied abstraction to enforce implementation in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // I applied polymorphic summary generation using overridden virtual/abstract methods
    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        
        string activityName = this.GetType().Name;
        string formattedDate = _activityDate.ToString("dd MMM yyyy");

        return $"{formattedDate} {activityName} ({_durationMinutes} min): Distance {distance:F1} km, Speed: {speed:F1} kph, Pace: {pace:F2} min per km";
    }
}