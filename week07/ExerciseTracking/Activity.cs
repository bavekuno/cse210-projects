
// The base class for all exercise activities.
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods to be overridden by derived classes for calculating distance, speed, and pace.
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Provides a formatted summary of the activity. This method uses the polymorphic methods from the derived classes.
    public virtual string GetSummary()
    {
        string formattedDate = _date.ToString("dd MMM yyyy");
        string activityType = GetType().Name; // Gets the name of the derived class.
        double distance = Math.Round(GetDistance(), 2);
        double speed = Math.Round(GetSpeed(), 2);
        double pace = Math.Round(GetPace(), 2);

        return $"{formattedDate} {activityType} ({_minutes} min) - Distance: {distance} miles, Speed: {speed} mph, Pace: {pace} min per mile";
    }
}
