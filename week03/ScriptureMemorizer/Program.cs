
using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture
            Reference reference = new Reference("John", 3, 16);
            Scripture scripture = new Scripture("For God so loved the world that he gave his only begotten Son", reference);

            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Try to memorize the scripture. You can type 'quit' to exit or type the full scripture to finish early.");
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Goodbye!");
                    break;
                }

                int hiddenCount = scripture.GetHiddenWordCount();
                int totalWords = scripture.GetTotalWordCount();
                Console.WriteLine($"\nProgress: {hiddenCount}/{totalWords} words hidden.");

                Console.WriteLine("\nPress Enter to hide more words, type 'quit' to exit, or type the full scripture to finish.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (scripture.IsFullScriptureCorrect(input))
                {
                    Console.WriteLine("\nCongratulations! You typed the full scripture correctly. Goodbye!");
                    break;
                }

                scripture.HideRandomWords();
            }
        }
    }
}



// This program exceeds the core requirements by:
// 1. Implementing enhanced hiding logic to ensure only non-hidden words are selected for hiding.
// 2. Providing progress tracking by displaying the number of hidden words and the total word count after each step.
// 3. Gives an option to type the full scripture to end the program.
// These features improve user experience by ensuring meaningful word hiding and tracking progress more effectively.


