//i added ideas for gamification like leveling up, earning certain bonuses during the quest.

using System;
using System.Collections.Generic;
using System.IO;


// The main program entry point.
public class Program
{
    public static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}