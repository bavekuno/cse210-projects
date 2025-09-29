
// Manages the list of goals, player's score, and gamification elements.
public class GoalManager
{
    private List<Goal> _goals;
    private int _experiencePoints;
    private int _level;
    private List<Achievement> _achievements;
    private int _eternalEventsCount = 0; // Track EternalGoal events

    public GoalManager()
    {
        _goals = new List<Goal>();
        _experiencePoints = 0;
        _level = 1;
        _achievements = new List<Achievement>();
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        _achievements.Add(new Achievement("Newbie Navigator", "Create your first goal."));
        _achievements.Add(new Achievement("Goal Getter", "Complete 5 simple goals."));
        _achievements.Add(new Achievement("Eternal Devotion", "Record 10 events for Eternal Goals."));
        _achievements.Add(new Achievement("Checklist Champion", "Complete a checklist goal."));
        _achievements.Add(new Achievement("Master Motivator", "Reach Level 5."));
    }

    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. View Achievements");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    ViewAchievements();
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nLevel: {_level}");
        Console.WriteLine($"Experience: {_experiencePoints} / {GetNextLevelExp()}");
        DisplayLevelProgress();
        Console.WriteLine();
    }

    private void DisplayLevelProgress()
    {
        int totalExpForLevel = GetNextLevelExp();
        int currentLevelExp = _experiencePoints - GetExpForCurrentLevel();
        int expNeeded = totalExpForLevel - GetExpForCurrentLevel();
        double progress = (double)currentLevelExp / expNeeded;
        int barLength = 20;
        int filledLength = (int)(progress * barLength);
        string progressBar = "[" + new string('#', filledLength) + new string('-', barLength - filledLength) + "]";
        Console.WriteLine($"Progress to next level: {progressBar}");
    }

    private int GetNextLevelExp()
    {
        return _level * 1000;
    }

    private int GetExpForCurrentLevel()
    {
        if (_level == 1) return 0;
        return (_level - 1) * 1000;
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"  {i + 1}. ");
            _goals[i].DisplayGoalStatus();
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            CheckForAchievement("Newbie Navigator");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal goal = _goals[goalIndex - 1];
            int pointsEarned = goal.RecordEvent();
            if (pointsEarned > 0)
            {
                _experiencePoints += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                CheckLevelUp();

                // Track EternalGoal events
                if (goal is EternalGoal)
                {
                    _eternalEventsCount++;
                }

                CheckForEventAchievements(goal);

            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void CheckLevelUp()
    {
        int requiredExp = GetNextLevelExp();
        if (_experiencePoints >= requiredExp)
        {
            _level++;
            Console.WriteLine($"\n🌟 Congratulations! You have leveled up to Level {_level}! 🌟");
            CheckForAchievement("Master Motivator");
        }
    }

    private void CheckForEventAchievements(Goal goal)
    {
        if (goal is SimpleGoal && goal.IsComplete())
        {
            int completedSimpleGoals = 0;
            foreach (var g in _goals)
            {
                if (g is SimpleGoal && g.IsComplete())
                {
                    completedSimpleGoals++;
                }
            }

            if (completedSimpleGoals >= 5)
            {
                CheckForAchievement("Goal Getter");
            }
        }
        else if (goal is EternalGoal)
        {
            if (_eternalEventsCount >= 10)
            {
                CheckForAchievement("Eternal Devotion");
            }
        }
        else if (goal is ChecklistGoal && goal.IsComplete())
        {
            CheckForAchievement("Checklist Champion");
        }
    }

    private void CheckForAchievement(string name)
    {
        Achievement achievement = _achievements.Find(a => a.Name == name);
        if (achievement != null && !achievement.IsEarned)
        {
            achievement.IsEarned = true;
            Console.WriteLine($"\n🎉 Achievement Unlocked: {achievement.Name} 🎉");
            Console.WriteLine($"Description: {achievement.Description}\n");
        }
    }

    public void ViewAchievements()
    {
        Console.WriteLine("\n--- Your Achievements ---");
        foreach (var achievement in _achievements)
        {
            string status = achievement.IsEarned ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {achievement.Name}: {achievement.Description}");
        }
        Console.WriteLine("-------------------------\n");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_experiencePoints);
            outputFile.WriteLine(_level);
            outputFile.WriteLine(_eternalEventsCount); // Save eternal events count
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
            outputFile.WriteLine("Achievements:");
            foreach (var achievement in _achievements)
            {
                outputFile.WriteLine($"{achievement.Name},{achievement.IsEarned}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        _goals.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _experiencePoints = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _eternalEventsCount = int.Parse(lines[2]); // Load eternal events count

            int i = 3;
            while (i < lines.Length && !lines[i].StartsWith("Achievements:"))
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2]), false));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
                        break;
                }
                i++;
            }

            // Load Achievements
            _achievements.Clear();
            InitializeAchievements(); // Reset achievements to default
            for (i++; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                string name = parts[0];
                bool isEarned = bool.Parse(parts[1]);
                Achievement achievement = _achievements.Find(a => a.Name == name);
                if (achievement != null)
                {
                    achievement.IsEarned = isEarned;
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Starting a new game.");
            _experiencePoints = 0;
            _level = 1;
            _eternalEventsCount = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
    }
}