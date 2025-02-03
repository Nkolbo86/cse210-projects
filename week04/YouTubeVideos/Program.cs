using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"- {CommenterName}: {CommentText}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        comments.Add(new Comment(commenterName, commentText));
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"📺 Title: {Title}");
        Console.WriteLine($"👤 Author: {Author}");
        Console.WriteLine($"⏳ Length: {Length} seconds");
        Console.WriteLine($"💬 Comments ({GetCommentCount()}):");

        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine("----------------------");
    }
}

class Program
{
    static void Main()
    {
        // Create 3 videos
        Video video1 = new Video("C# Basics", "Code Academy", 600);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "This helped a lot, thanks!");
        video1.AddComment("Charlie", "I love C#!");

        Video video2 = new Video("Encapsulation in OOP", "DevSchool", 450);
        video2.AddComment("Dave", "Encapsulation is so useful!");
        video2.AddComment("Eve", "The example was clear.");
        video2.AddComment("Frank", "Good explanation!");

        Video video3 = new Video("How to Debug in VS Code", "TechExplained", 720);
        video3.AddComment("Grace", "This saved me hours of frustration!");
        video3.AddComment("Hank", "Debugging is now so much easier.");
        video3.AddComment("Ivy", "Clear and helpful tutorial!");

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video and its comments
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
