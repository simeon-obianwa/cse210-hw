using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph) : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance() => (_speedKph / 60.0) * _durationMinutes;
    
    public override double GetSpeed() => _speedKph;
    
    public override double GetPace() => _durationMinutes / GetDistance();
}