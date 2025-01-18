using System;
using System.Collections.Generic;

public class Journal
{
    // Attribute
    public List<Entry> _entries = new List<Entry>();

    // Method to add an entry
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Method to display all entries
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}
