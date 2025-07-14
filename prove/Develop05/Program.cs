using System;
using System.Collections.Generic;
using System.IO;


using System;


// Parent of all Goals
public abstract class Goal
{
    protected string _goalType;
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completionStatus;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completionStatus = false;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetFormattedGoalName();

    public virtual string SaveString()
    {
        return $"{_goalType}|{_name}|{_description}|{_points}|{_completionStatus}";
    }

    public virtual void LoadData(string[] parts)
    {
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _completionStatus = bool.Parse(parts[4]);
    }

    public int GetPoints() => _points;
    public string GetName() => _name;
    public bool GetCompletionStatus() => _completionStatus;
}


// Simple Goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _goalType = "Simple";
    }

    public override void RecordEvent()
    {
        if (!_completionStatus)
        {
            _completionStatus = true;
            Console.WriteLine($"You earned {_points} points!");
        }
    }

    public override bool IsComplete() => _completionStatus;

    public override string GetFormattedGoalName()
    {
        return $"[{"X",1}] {_name} ({_description})";
    }
}


// Eternal Goals
public class EternalGoal : Goal
{
    private int _counter;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _goalType = "Eternal";
        _counter = 0;
    }

    public override void RecordEvent()
    {
        _counter++;
        Console.WriteLine($"You earned {_points} points! (Total recorded: {_counter})");
    }

    public override bool IsComplete() => false;

    public override string GetFormattedGoalName()
    {
        return $"[ ] {_name} ({_description}) (Completed {_counter} times)";
    }

    public override string SaveString()
    {
        return base.SaveString() + $"|{_counter}";
    }

    public override void LoadData(string[] parts)
    {
        base.LoadData(parts);
        _counter = int.Parse(parts[5]);
    }
}


// Checklist Goals
public class ChecklistGoal : Goal
{
    private int _timesToRepeat;
    private int _timesCompleted;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int timesToRepeat, int bonusPoints)
        : base(name, description, points)
    {
        _goalType = "Checklist";
        _timesToRepeat = timesToRepeat;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (_timesCompleted < _timesToRepeat)
        {
            _timesCompleted++;
            int totalPoints = _points;
            if (_timesCompleted == _timesToRepeat)
            {
                _completionStatus = true;
                totalPoints += _bonusPoints;
            }
            Console.WriteLine($"You earned {totalPoints} points!");
        }
    }

    public override bool IsComplete() => _completionStatus;

    public override string GetFormattedGoalName()
    {
        return $"[{_timesCompleted}/{_timesToRepeat}] {_name} ({_description})";
    }

    public override string SaveString()
    {
        return base.SaveString() + $"|{_timesToRepeat}|{_timesCompleted}|{_bonusPoints}";
    }

    public override void LoadData(string[] parts)
    {
        base.LoadData(parts);
        _timesToRepeat = int.Parse(parts[5]);
        _timesCompleted = int.Parse(parts[6]);
        _bonusPoints = int.Parse(parts[7]);
    }
}



public class Program
{
    private static int _userScore = 0;
    private static List<Goal> _goals = new List<Goal>();

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            DisplayMainMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    RecordEventMenu();
                    break;
                case "3":
                    SaveGoalMenu();
                    break;
                case "4":
                    LoadGoalMenu();
                    break;
                case "5":
                    DisplayGoals();
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }

    private static void DisplayMainMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Create Goal");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Display Goals");
        Console.WriteLine("6. Quit");
    }

    private static void CreateGoalMenu()
    {
        Console.WriteLine("Choose goal type (1 = Simple, 2 = Eternal, 3 = Checklist):");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Times to repeat: ");
                int repeat = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, repeat, bonus));
                break;
        }
    }

    private static void RecordEventMenu()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetFormattedGoalName()}");
        }

        Console.Write("Choose a goal to record: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _goals[choice].RecordEvent();
            _userScore += _goals[choice].GetPoints();
        }
    }

    private static void SaveGoalMenu()
    {
        Console.Write("Enter the filename to save to (e.g., goals.txt): ");
        string fileName = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.WriteLine(_userScore);
            foreach (var goal in _goals)
            {
                sw.WriteLine(goal.SaveString());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private static void LoadGoalMenu()
    {
        Console.Write("Enter the filename to load from (e.g., goals.txt): ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(fileName);
        _userScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            Goal goal = null;

            switch (parts[0])
            {
                case "Simple":
                    goal = new SimpleGoal("", "", 0);
                    break;
                case "Eternal":
                    goal = new EternalGoal("", "", 0);
                    break;
                case "Checklist":
                    goal = new ChecklistGoal("", "", 0, 0, 0);
                    break;
            }

            goal?.LoadData(parts);
            _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded.");
    }

    private static void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetFormattedGoalName()}");
        }
    }
}
