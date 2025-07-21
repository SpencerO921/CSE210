using System;
using System.Collections.Generic;
using System.Globalization;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // miles
    public virtual double GetSpeed() => (GetDistance() / _minutes) * 60; // mph
    public virtual double GetPace() => _minutes / GetDistance(); // min per mile

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed / 60) * Minutes;
    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62;
}

class Program
{
    static void Main(string[] args)
    {
        // Exercise tracking program
        Console.WriteLine("Hello Foundation4 World!");

        List<Activity> activities = new List<Activity>();

        Console.Write("How many activities would you like to enter? ");
        int numActivities = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numActivities; i++)
        {
            Console.WriteLine($"\nActivity #{i}");

            Console.Write("Enter activity type (Running, Cycling, Swimming): ");
            string type = Console.ReadLine().Trim().ToLower();

            Console.Write("Enter the date (yyyy-mm-dd): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            Console.Write("Enter duration in minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "running":
                    Console.Write("Enter distance (in miles): ");
                    double runDistance = double.Parse(Console.ReadLine());
                    activities.Add(new Running(date, minutes, runDistance));
                    break;

                case "cycling":
                    Console.Write("Enter speed (in mph): ");
                    double speed = double.Parse(Console.ReadLine());
                    activities.Add(new Cycling(date, minutes, speed));
                    break;

                case "swimming":
                    Console.Write("Enter number of laps: ");
                    int laps = int.Parse(Console.ReadLine());
                    activities.Add(new Swimming(date, minutes, laps));
                    break;

                default:
                    Console.WriteLine("Invalid activity type. Skipping this entry.");
                    break;
            }
        }

        Console.WriteLine("\n=== Activity Summaries ===");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
    