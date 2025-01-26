using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a reference
        Reference reference = new Reference("John", 3, 16);

        // Create a scripture with the reference and text
        Scripture scripture = new Scripture("For God so loved the world that he gave his only begotten Son", reference);

        // Display the scripture
        Console.WriteLine(scripture.GetDisplayText());

        // Hide words progressively until all are hidden
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
            Console.WriteLine(scripture.GetDisplayText());
        }

        Console.WriteLine("\nGoodbye!");
    }
}
