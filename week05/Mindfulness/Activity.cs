// The base class for all mindfulness activities.
// It contains shared properties and methods for displaying common messages and animations.
public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Displays the starting message for any activity and prompts the user for a duration.
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    // Displays the ending message for any activity.
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    //Shows a simple spinner animation for a given number of seconds.
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string frame = spinnerFrames[i];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= spinnerFrames.Count)
            {
                i = 0;
            }
        }
    }

    //Shows a countdown animation from a given number of seconds
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            if (i >= 10)
            {
                Console.Write("\b \b");
            }
        }
    }
}