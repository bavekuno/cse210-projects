
// A class to represent an achievement or badge.
public class Achievement
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsEarned { get; set; }

    public Achievement(string name, string description, bool isEarned = false)
    {
        Name = name;
        Description = description;
        IsEarned = isEarned;
    }
}