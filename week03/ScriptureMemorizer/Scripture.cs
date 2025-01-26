using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(string verseText, Reference reference)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the verse text into words and create Word objects
        string[] words = verseText.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    // Method to hide random words
    public void HideRandomWords()
    {
        Random random = new Random();
        foreach (Word word in _words)
        {
            if (!word.IsHidden() && random.Next(0, 2) == 0)
            {
                word.Hide();
            }
        }
    }

    // Method to return the scripture with hidden words
    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}: {scriptureText.Trim()}";
    }

    // Method to check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
