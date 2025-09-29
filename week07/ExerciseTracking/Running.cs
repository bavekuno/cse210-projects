
// Represents a running activity.
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0 || GetDistance() == 0) return 0;
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        if (GetDistance() == 0) return 0;
        return GetMinutes() / GetDistance();
    }
}
