using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine($"Your Score: {_score} | Level: {GetLevel()} | Title: {GetTitle()}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, desc, points));

        else if (type == "2")
            _goals.Add(new EternalGoal(name, desc, points));

        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));

            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));

            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                    int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
        }
    }

    // 🎮 EXCEEDING REQUIREMENTS — Gamification System
    private int GetLevel() => _score / 1000;

    private string GetTitle()
    {
        int level = GetLevel();

        if (level >= 10) return "Celestial Champion";
        if (level >= 5) return "Spiritual Warrior";
        if (level >= 2) return "Disciple in Training";
        return "Beginner";
    }
}
