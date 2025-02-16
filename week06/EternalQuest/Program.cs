using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        while (true)
        {
            Console.WriteLine("\nEternal Quest - Goal Tracker");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Select Goal Type: 1. Simple, 2. Eternal, 3. Checklist");
                    string typeChoice = Console.ReadLine();
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter goal points: ");
                    int points = int.Parse(Console.ReadLine());

                    if (typeChoice == "1")
                    {
                        manager.AddGoal(new SimpleGoal(name, description, points));
                    }
                    else if (typeChoice == "2")
                    {
                        manager.AddGoal(new EternalGoal(name, description, points));
                    }
                    else if (typeChoice == "3")
                    {
                        Console.Write("Enter required completions: ");
                        int requiredCompletions = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, description, points, requiredCompletions, bonusPoints));
                    }
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    Console.Write("Enter goal number to record event: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(goalIndex);
                    break;

                case "4":
                    manager.SaveGoals("goals.txt");
                    break;

                case "5":
                    manager.LoadGoals("goals.txt");
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
