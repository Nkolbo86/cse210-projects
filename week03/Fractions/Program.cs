using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the Fraction class with all three constructors
        Fraction fraction1 = new Fraction(); // 1/1
        Fraction fraction2 = new Fraction(5); // 5/1
        Fraction fraction3 = new Fraction(3, 4); // 3/4

        // Display initial values
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Test getters and setters
        fraction3.SetNumerator(1);
        fraction3.SetDenominator(3);

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}
