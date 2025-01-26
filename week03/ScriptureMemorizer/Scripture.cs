using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private string _fullText;

        public Scripture(string text, Reference reference)
        {
            _reference = reference;
            _words = new List<Word>();
            _fullText = text;

            foreach (string word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords()
        {
            Random random = new Random();
            int wordsToHide = 2; // Set how many words to hide each time
            int hiddenCount = 0;

            while (hiddenCount < wordsToHide)
            {
                int index = random.Next(0, _words.Count);
                Word word = _words[index];

                if (!word.IsHidden())
                {
                    word.Hide();
                    hiddenCount++;
                }

                if (IsCompletelyHidden())
                {
                    break;
                }
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = "";
            foreach (Word word in _words)
            {
                scriptureText += word.GetDisplayText() + " ";
            }
            return $"{_reference.GetDisplayText()}: {scriptureText.Trim()}";
        }

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

        public bool IsFullScriptureCorrect(string input)
        {
            return input.Trim().Equals(_fullText, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHiddenWordCount()
        {
            int count = 0;
            foreach (Word word in _words)
            {
                if (word.IsHidden())
                {
                    count++;
                }
            }
            return count;
        }

        public int GetTotalWordCount()
        {
            return _words.Count;
        }
    }
}
