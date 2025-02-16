public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredCompletions;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredCompletions, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredCompletions = requiredCompletions;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"Recorded event for '{_name}'. You earned {_points} points.");

        if (_timesCompleted >= _requiredCompletions)
        {
            Console.WriteLine($"Congratulations! '{_name}' is fully completed! Bonus {_bonusPoints} points earned!");
        }
    }

    public override string GetDetailsString()
    {
        return $"[{_timesCompleted}/{_requiredCompletions}] {_name} - {_description}";
    }

    public int GetRequiredCompletions()
    {
        return _requiredCompletions;
    }

    public int GetCurrentCompletions()
    {
        return _timesCompleted;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public void SetCurrentCompletions(int count)
    {
        _timesCompleted = count;
    }
}
