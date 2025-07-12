using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
    }

    public override int GetPoints()
    {
        return _isComplete ? _points : 0;
    }
}
