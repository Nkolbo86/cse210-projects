using System;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture("For God so loved the world that he gave his only begotten Son", reference);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Goodbye!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            scripture.HideRandomWords();
        }
    }
}
