using System;
using System.Collections.Generic;
using System.IO;

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

    // Save journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    // Load journal from a file
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(entry);
                }
            }
        }
    }
}
