

// Represents an eternal goal that can be recorded multiple times.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Constructor for loading from a file.
    public EternalGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void DisplayGoalStatus()
    {
        Console.WriteLine($"[ ] {GetShortName()} ({GetDescription()})");
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()},{GetDescription()},{_points}";
    }
}