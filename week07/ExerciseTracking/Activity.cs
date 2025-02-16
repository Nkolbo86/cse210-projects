// Base class for all activities
public abstract class Activity
{
    protected string _date;
    protected int _durationMinutes;

    public Activity(string date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date}: {_durationMinutes} min - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

// Running class
public class Running : Activity
{
    private double _distance;

    public Running(string date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / _durationMinutes) * 60;
    public override double GetPace() => _durationMinutes / _distance;
}

// Cycling class
public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * _durationMinutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
}

// Swimming class
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(string date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * LapLengthMeters) * MetersToMiles;
    public override double GetSpeed() => (GetDistance() / _durationMinutes) * 60;
    public override double GetPace() => _durationMinutes / GetDistance();
}
