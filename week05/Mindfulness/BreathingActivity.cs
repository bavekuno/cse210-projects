
// The BreathingActivity class guides the user through a breathing exercise.
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    //Runs the breathing activity loop.
    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}