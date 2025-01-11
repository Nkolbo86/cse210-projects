using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter;
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Add "+" or "-" based on the last digit
        int lastDigit = gradePercentage % 10;

        if (letter != "F") // Only add signs for grades above F
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Handle special cases for A+ and F signs
        if (letter == "A" && sign == "+")
        {
            sign = ""; // There is no A+
        }

        if (letter == "F")
        {
            sign = ""; // There is no F+ or F-
        }

        // Print the letter grade with the sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the user passed or failed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time.");
        }
    }
}
