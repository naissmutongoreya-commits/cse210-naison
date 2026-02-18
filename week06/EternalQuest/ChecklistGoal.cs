using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = completed;
    }

    public override int RecordEvent()
    {
        if (_timesCompleted < _target)
        {
            _timesCompleted++;
            int total = GetPoints();

            if (_timesCompleted == _target)
            {
                total += _bonus;
            }

            return total;
        }
        return 0;
    }

    public override bool IsComplete() => _timesCompleted >= _target;

    public override string GetStatus()
    {
        return $"[{(_timesCompleted >= _target ? "X" : " ")}] Completed {_timesCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_timesCompleted}";
    }
}
