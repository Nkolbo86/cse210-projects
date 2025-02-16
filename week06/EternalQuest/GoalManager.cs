using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;
    private int _xp;
    private int _level;
    private List<string> _achievements;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
        _xp = 0;
        _level = 1;
        _achievements = new List<string>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
            int earnedPoints = _goals[goalIndex].GetPoints();
            _totalScore += earnedPoints;
            _xp += earnedPoints / 10; // XP gained is 10% of points earned

            if (_xp >= _level * 50) // Level up every 50 XP per level
            {
                _xp = 0;
                _level++;
                Console.WriteLine($"🎉 Level Up! You are now Level {_level}!");
            }
            CheckAchievements();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void CheckAchievements()
    {
        if (_totalScore >= 500 && !_achievements.Contains("500 Points Badge"))
        {
            _achievements.Add("500 Points Badge");
            Console.WriteLine("🏆 Achievement Unlocked: 500 Points Badge!");
        }

        if (_level == 5 && !_achievements.Contains("Level 5 Badge"))
        {
            _achievements.Add("Level 5 Badge");
            Console.WriteLine("🏆 Achievement Unlocked: Level 5!");
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"\nTotal Score: {_totalScore}");
        Console.WriteLine($"XP: {_xp}, Level: {_level}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalScore); // Save the total score
            writer.WriteLine(_xp);
            writer.WriteLine(_level);
            writer.WriteLine(string.Join(",", _achievements)); // Save achievements

            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal)
                {
                    writer.WriteLine($"SimpleGoal|{goal.GetName()}|{goal.GetPoints()}");
                }
                else if (goal is EternalGoal)
                {
                    writer.WriteLine($"EternalGoal|{goal.GetName()}|{goal.GetPoints()}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"ChecklistGoal|{goal.GetName()}|{goal.GetPoints()}|{checklistGoal.GetRequiredCompletions()}|{checklistGoal.GetCurrentCompletions()}|{checklistGoal.GetBonusPoints()}");
                }
                else if (goal is NegativeGoal negativeGoal)
                {
                    writer.WriteLine($"NegativeGoal|{goal.GetName()}|{goal.GetPoints()}");
                }
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _totalScore = int.Parse(lines[0]); // First line is the total score
            _xp = int.Parse(lines[1]);
            _level = int.Parse(lines[2]);
            _achievements = new List<string>(lines[3].Split(','));
            _goals.Clear(); // Clear existing goals before loading

            for (int i = 4; i < lines.Length; i++) // Start from fifth line
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(name, "", points));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, "", points));
                }
                else if (type == "ChecklistGoal")
                {
                    int requiredCompletions = int.Parse(parts[3]);
                    int currentCompletions = int.Parse(parts[4]);
                    int bonusPoints = int.Parse(parts[5]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, "", points, requiredCompletions, bonusPoints);
                    checklistGoal.SetCurrentCompletions(currentCompletions);
                    _goals.Add(checklistGoal);
                }
                else if (type == "NegativeGoal")
                {
                    _goals.Add(new NegativeGoal(name, "", points));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goal file found.");
        }
    }
}

// Bonus Features (For Extra Credit) 
// 🎮 Leveling System: Gain XP as you complete goals and level up. 
// 🏆 Achievements: Unlock badges for streaks or milestone goals. 
// ❌ Negative Goals: Lose points for bad habits. 
// 📅 Reminders: Schedule notifications for checklist goals.