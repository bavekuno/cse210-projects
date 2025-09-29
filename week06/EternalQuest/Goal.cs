// The base class for all types of goals. It defines common properties and behaviors.
public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Abstract method to be implemented by derived classes to record an event and return points.
    public abstract int RecordEvent();

    // Abstract method to be implemented by derived classes to check if the goal is complete.
    public abstract bool IsComplete();

    // Virtual method to display the goal status, which can be overridden.
    public virtual void DisplayGoalStatus()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_shortName} ({_description})");
    }

    // Abstract method to be implemented by derived classes for saving to a file.
    public abstract string GetStringRepresentation();
}
