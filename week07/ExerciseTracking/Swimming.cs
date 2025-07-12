using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (miles) = swimming laps * 50 / 1000 * 0.62
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _minutes) * 60; // mph
    }

    public override double GetPace()
    {
        return _minutes / GetDistance(); // minutes per mile
    }

    protected override string GetActivityType()
    {
        return "Swimming";
    }
}
