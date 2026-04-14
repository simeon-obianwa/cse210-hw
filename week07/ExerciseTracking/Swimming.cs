using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // 50 meters per lap -> convert to km: * 50 / 1000
    public override double GetDistance() => _laps * 50.0 / 1000.0;
    
    public override double GetSpeed() => (GetDistance() / _durationMinutes) * 60.0;
    
    public override double GetPace() => _durationMinutes / GetDistance();
}