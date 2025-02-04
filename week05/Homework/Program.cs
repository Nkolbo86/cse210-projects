using System;

// Base Class: Assignment
public class Assignment {
    protected string _studentName;
    protected string _topic;

    public Assignment(string studentName, string topic) {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary() {
        return $"{_studentName} - {_topic}";
    }
}

// Derived Class: MathAssignment
public class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic) {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList() {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}

// Derived Class: WritingAssignment
public class WritingAssignment : Assignment {
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic) {
        _title = title;
    }

    public string GetWritingInformation() {
        return $"{_title} by {_studentName}";
    }
}

// Main Program
class Program {
    static void Main(string[] args) {
        // Test Assignment Class
        Assignment generalAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(generalAssignment.GetSummary());

        // Test MathAssignment Class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Test WritingAssignment Class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
