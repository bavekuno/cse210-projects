
// Represents a checklist goal that must be completed a certain number of times for a bonus.
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    // Constructor for loading from a file.
    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonusPoints) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (IsComplete())
        {
            Console.WriteLine($"You earned a bonus of {_bonusPoints} points!");
            return _points + _bonusPoints;
        }
        else
        {
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override void DisplayGoalStatus()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}");
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{_points},{_amountCompleted},{_target},{_bonusPoints}";
    }
}