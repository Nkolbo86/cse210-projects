using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a journal
        Journal myJournal = new Journal();

        // Add some entries
        Entry entry1 = new Entry("2025-01-18", "What made you happy today?", "Spending time with family.");
        Entry entry2 = new Entry("2025-01-19", "What did you learn today?", "I learned about abstraction in programming.");

        myJournal.AddEntry(entry1);
        myJournal.AddEntry(entry2);

        // Display the journal
        Console.WriteLine("Journal Entries:");
        myJournal.Display();
    }
}
