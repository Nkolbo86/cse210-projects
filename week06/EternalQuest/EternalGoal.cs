public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for '{_name}'. You earned {_points} points.");
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_name} - {_description}";
    }
}
