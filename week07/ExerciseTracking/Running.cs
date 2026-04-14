using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm) : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;
    
    public override double GetSpeed() => (_distanceKm / _durationMinutes) * 60.0;
    
    public override double GetPace() => _durationMinutes / _distanceKm;
}