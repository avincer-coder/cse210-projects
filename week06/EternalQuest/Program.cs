using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; protected set; }
    public abstract void RecordEvent();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    private bool IsCompleted;
    
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }
    
    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' already completed.");
        }
    }
    
    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }
    
    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' recorded! +{Points} points");
    }
    
    public override string GetStatus()
    {
        return "[∞] " + Name;
    }
}

class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int Bonus;
    
    public ChecklistGoal(string name, int points, int targetCount, int bonus)
    {
        Name = name;
        Points = points;
        TargetCount = targetCount;
        Bonus = bonus;
        CurrentCount = 0;
    }
    
    public override void RecordEvent()
    {
        CurrentCount++;
        int totalPoints = Points;
        if (CurrentCount == TargetCount)
        {
            totalPoints += Bonus;
            Console.WriteLine($"Goal '{Name}' completed! Bonus +{Bonus} points!");
        }
        Console.WriteLine($"Goal '{Name}' progress: {CurrentCount}/{TargetCount}. +{totalPoints} points");
    }
    
    public override string GetStatus()
    {
        return $"[{(CurrentCount >= TargetCount ? "X" : "⧖")}] {Name} (Completed {CurrentCount}/{TargetCount} times)";
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int TotalScore = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Create Goal\n2. Record Event\n3. Show Goals\n4. Exit");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": ShowGoals(); break;
                case "4": return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select goal type: 1. Simple 2. Eternal 3. Checklist");
        string type = Console.ReadLine();
        
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());
        
        switch (type)
        {
            case "1": goals.Add(new SimpleGoal(name, points)); break;
            case "2": goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type");
                break;
        }
    }
    
    static void RecordEvent()
    {
        ShowGoals();
        Console.WriteLine("Select the index of the goal you want to record an event for.");
        Console.WriteLine("[ ] = Incomplete Goal, [X] = Completed Goal, [∞] = Eternal Goal (can be repeated), [⧖] = Checklist Goal in progress.");
        Console.Write("Enter the goal index: ");
        int index = int.Parse(Console.ReadLine());
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            TotalScore += goals[index].Points;
        }
        else
        {
            Console.WriteLine("Invalid index. Please enter a valid number from the list.");
        }
    }
    
    static void ShowGoals()
    {
        Console.WriteLine($"Total Score: {TotalScore}");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i}. {goals[i].GetStatus()}");
        }
    }
}
