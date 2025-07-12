using System;

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _minutes) / 60; // distance = speed * time
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed; // minutes per mile
    }

    protected override string GetActivityType()
    {
        return "Cycling";
    }
}
