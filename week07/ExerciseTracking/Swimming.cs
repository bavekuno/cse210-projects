
// Represents a swimming activity. A lap is 50 meters.
public class Swimming : Activity
{
    private int _laps;
    private const double MetersPerMile = 1609.34;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in miles: (laps * 50 meters) / meters per mile
        return (_laps * 50) / MetersPerMile;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0) return 0;
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        if (GetDistance() == 0) return 0;
        return GetMinutes() / GetDistance();
    }
}
