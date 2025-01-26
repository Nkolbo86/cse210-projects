public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    // Constructor
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Method to return the reference as a formatted string
    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}
