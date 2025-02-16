public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"⚠️ You did '{_name}'. You lost {_points} points.");
    }

    public override string GetDetailsString()
    {
        return $"❌ {_name} - {_description} (Penalty: -{_points} Points)";
    }
}
