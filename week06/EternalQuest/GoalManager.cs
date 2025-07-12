using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("Embark on your journey to become a Legendary Goal Achiever!");
        Console.WriteLine();

        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            choice = DisplayMenu();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Thanks for using the Eternal Quest Program! Keep achieving your goals!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");

        // Gamification: Level system
        int level = CalculateLevel(_score);
        string title = GetPlayerTitle(level);
        Console.WriteLine($"Level: {level} - {title}");

        int pointsToNextLevel = CalculatePointsToNextLevel(_score);
        if (pointsToNextLevel > 0)
        {
            Console.WriteLine($"Points needed to next level: {pointsToNextLevel}");
        }
        Console.WriteLine();
    }

    public int DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice))
        {
            return choice;
        }
        return 0;
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int goalType) || goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        Goal newGoal = null;

        switch (goalType)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for completion? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value.");
                    return;
                }

                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first!");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal selectedGoal = _goals[goalIndex - 1];

        if (selectedGoal.IsComplete() && !(selectedGoal is EternalGoal))
        {
            Console.WriteLine("This goal is already complete!");
            return;
        }

        int pointsBefore = selectedGoal.GetPoints();
        selectedGoal.RecordEvent();
        int pointsAfter = selectedGoal.GetPoints();
        int pointsEarned = pointsAfter - pointsBefore;

        // For eternal goals, always give points
        if (selectedGoal is EternalGoal)
        {
            pointsEarned = selectedGoal.GetPoints();
        }

        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");

        // Check for level up
        CheckForLevelUp();

        // Special celebration for checklist goal completion
        if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            Console.WriteLine("🎉 Bonus! You completed a checklist goal! 🎉");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("Empty file.");
                return;
            }

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                Goal goal = CreateGoalFromString(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(':');
        if (parts.Length != 2) return null;

        string goalType = parts[0];
        string[] data = parts[1].Split(',');

        switch (goalType)
        {
            case "SimpleGoal":
                if (data.Length >= 4)
                {
                    SimpleGoal simpleGoal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                    if (bool.Parse(data[3]))
                    {
                        simpleGoal.RecordEvent();
                    }
                    return simpleGoal;
                }
                break;

            case "EternalGoal":
                if (data.Length >= 3)
                {
                    return new EternalGoal(data[0], data[1], int.Parse(data[2]));
                }
                break;

            case "ChecklistGoal":
                if (data.Length >= 6)
                {
                    ChecklistGoal checklistGoal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                                                   int.Parse(data[4]), int.Parse(data[3]));
                    checklistGoal.SetAmountCompleted(int.Parse(data[5]));
                    return checklistGoal;
                }
                break;
        }

        return null;
    }

    // Gamification features
    private int CalculateLevel(int score)
    {
        return (score / 1000) + 1;
    }

    private string GetPlayerTitle(int level)
    {
        string[] titles = {
            "Novice Dreamer",
            "Aspiring Achiever",
            "Determined Doer",
            "Focused Fighter",
            "Persistent Pursuer",
            "Dedicated Devotee",
            "Committed Conqueror",
            "Steadfast Striver",
            "Unwavering Warrior",
            "Legendary Goal Master",
            "Mythical Quest Champion",
            "Divine Achievement God"
        };

        if (level <= titles.Length)
        {
            return titles[level - 1];
        }
        else
        {
            return $"Transcendent Being (Level {level})";
        }
    }

    private int CalculatePointsToNextLevel(int score)
    {
        int currentLevel = CalculateLevel(score);
        int pointsForNextLevel = currentLevel * 1000;
        return Math.Max(0, pointsForNextLevel - score);
    }

    private void CheckForLevelUp()
    {
        int newLevel = CalculateLevel(_score);
        // This is a simplified level up check - in a full implementation you'd track previous level
        if (newLevel > 1 && _score % 1000 <= 100) // Rough approximation for recent level up
        {
            Console.WriteLine($"🎊 LEVEL UP! You are now a {GetPlayerTitle(newLevel)}! 🎊");
        }
    }
}
