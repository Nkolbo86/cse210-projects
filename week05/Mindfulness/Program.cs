using System;
using System.Collections.Generic;
using System.Threading;

// Base Activity Class
public class Activity {
    protected string activityName;
    protected string description;
    protected int duration;
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>();

    public Activity(string name, string desc) {
        activityName = name;
        description = desc;
    }

    public void StartActivity() {
        Console.WriteLine($"Starting {activityName}...\n{description}");
        Console.Write("Enter duration (seconds): ");
        duration = int.Parse(Console.ReadLine());
        IncrementActivityCount();
    }

    public void EndActivity() {
        Console.WriteLine($"Good job! You completed {activityName} for {duration} seconds.");
    }

    public void IncrementActivityCount() {
        if (!activityLog.ContainsKey(activityName)) {
            activityLog[activityName] = 0;
        }
        activityLog[activityName]++;
    }

    public static void DisplayActivityLog() {
        Console.WriteLine("Activity Log:");
        foreach (var entry in activityLog) {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }
}

// Breathing Activity
public class BreathingActivity : Activity {
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding your breathing.") {}

    public void RunBreathing() {
        for (int i = 0; i < duration / 2; i++) {
            Console.Write("Breathe in... ");
            Thread.Sleep(2000);
            Console.Write("\b\b\b\b\b\b\b\b\bBreathe out... ");
            Thread.Sleep(3000);
        }
    }
}

// Reflection Activity
public class ReflectionActivity : Activity {
    private List<string> prompts;
    private List<string> questions;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on meaningful moments.") {
        prompts = new List<string>() { "Think of a time when you stood up for someone else.", "Think of a time when you did something difficult." };
        questions = new List<string>() { "Why was this experience meaningful to you?", "How did you feel when it was complete?" };
    }

    public void RunReflection() {
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        foreach (string question in questions) {
            Console.WriteLine(question);
            Thread.Sleep(5000);
        }
    }
}

// Listing Activity
public class ListingActivity : Activity {
    private List<string> prompts;
    private List<string> userResponses;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in life.") {
        prompts = new List<string>() { "Who are people that you appreciate?", "What are personal strengths of yours?" };
        userResponses = new List<string>();
    }

    public void RunListing() {
        Console.WriteLine(prompts[new Random().Next(prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime) {
            Console.Write("Enter an item: ");
            userResponses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {userResponses.Count} items.");
    }
}

// Gratitude Activity
public class GratitudeActivity : Activity {
    private List<string> prompts;
    private List<string> userResponses;

    public GratitudeActivity() : base("Gratitude Activity", "This activity helps you appreciate things in your life.") {
        prompts = new List<string>() { "What are three things you're grateful for today?", "Who made a positive impact on your life recently?" };
        userResponses = new List<string>();
    }

    public void RunGratitude() {
        Console.WriteLine(prompts[new Random().Next(prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime) {
            Console.Write("Enter an item of gratitude: ");
            userResponses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You recorded {userResponses.Count} items of gratitude.");
    }
}

// Main Program
class Program {
    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("\nMindfulness Activities Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Show Activity Log");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.StartActivity();
                    breathing.RunBreathing();
                    breathing.EndActivity();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.StartActivity();
                    reflection.RunReflection();
                    reflection.EndActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.StartActivity();
                    listing.RunListing();
                    listing.EndActivity();
                    break;
                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.StartActivity();
                    gratitude.RunGratitude();
                    gratitude.EndActivity();
                    break;
                case "5":
                    Activity.DisplayActivityLog();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
