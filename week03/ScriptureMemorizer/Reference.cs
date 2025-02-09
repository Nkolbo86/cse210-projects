namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int? _endVerse;

        public Reference(string book, int chapter, int verse, int? endVerse = null)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
            {
                return $"{_book} {_chapter}:{_verse}-{_endVerse.Value}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verse}";
            }
        }
    }
}
