public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_name}' completed! You earned {_points} points.");
    }

    public override string GetDetailsString()
    {
        return _isComplete ? $"[X] {_name} - {_description}" : $"[ ] {_name} - {_description}";
    }
}

