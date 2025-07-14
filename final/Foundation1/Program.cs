// using System;
// using System.Runtime.CompilerServices;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // YouTube video foundation
//         Console.WriteLine("Hello Foundation1 World!");
//     }
// }

using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName;
    public string CommentText;

    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

class Video
{
    public string Title;
    public string Author;
    public int Length; // in seconds
    public List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds");
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            Console.WriteLine("  " + comment.CommenterName + ": " + comment.CommentText);
        }
        Console.WriteLine(); // Blank line after each video
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Amazing Product Review", "TechGuru", 320);
        video1.AddComment(new Comment("Alice", "This was super helpful!"));
        video1.AddComment(new Comment("Bob", "I love this product!"));
        video1.AddComment(new Comment("Charlie", "Very detailed explanation."));

        Video video2 = new Video("Unboxing the Future", "GadgetQueen", 450);
        video2.AddComment(new Comment("Dave", "Can't wait to get mine!"));
        video2.AddComment(new Comment("Ella", "Awesome unboxing skills."));
        video2.AddComment(new Comment("Frank", "Where did you buy it?"));

        Video video3 = new Video("Top 5 Must-Have Items", "LifeHacker", 280);
        video3.AddComment(new Comment("Grace", "Thanks for the recommendations!"));
        video3.AddComment(new Comment("Hannah", "Number 3 is my favorite."));
        video3.AddComment(new Comment("Ian", "More videos like this please!"));

        // Add videos to a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display info for each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
