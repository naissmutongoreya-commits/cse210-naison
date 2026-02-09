using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Learn C# Basics", "Code Academy", 600);
        Video video2 = new Video("Understanding Abstraction", "Programming Hub", 480);
        Video video3 = new Video("OOP in 10 Minutes", "Tech Simplified", 720);

        // Add comments to video 1
        video1.AddComment(new Comment("Alice", "Very helpful explanation!"));
        video1.AddComment(new Comment("Brian", "I finally understand C# basics."));
        video1.AddComment(new Comment("Chipo", "Great for beginners."));

        // Add comments to video 2
        video2.AddComment(new Comment("Daniel", "Abstraction is much clearer now."));
        video2.AddComment(new Comment("Esther", "Nice examples."));
        video2.AddComment(new Comment("Farai", "Straight to the point."));

        // Add comments to video 3
        video3.AddComment(new Comment("Grace", "Loved the simplicity."));
        video3.AddComment(new Comment("Henry", "Perfect quick overview."));
        video3.AddComment(new Comment("Ivy", "Well explained concepts."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
