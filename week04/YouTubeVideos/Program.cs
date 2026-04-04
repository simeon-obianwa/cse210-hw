using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    /// The entry point for the YouTube Product Awareness Tracker application.
    class Program
    {
        /// Main entry point for the application.
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            List<Video> videoList = new List<Video>();


            Video video1 = new Video("Understanding Abstraction", "CodeMaster", 345);
            Video video2 = new Video("Top 20 Dos", "TechGuru", 620);
            Video video3 = new Video("C# lesson for Beginners", "SimeonDevs", 1205);


            video1.AddComment(new Comment("Nick", "Great explanation!"));
            video1.AddComment(new Comment("Gab", "I finally get it."));
            video1.AddComment(new Comment("Rose", "Thanks for sharing."));


            video2.AddComment(new Comment("SeeDove54", "Where are the dogs?"));
            video2.AddComment(new Comment("JohnFan", "So great!"));
            video2.AddComment(new Comment("Viewer1", "Nice video."));
            video2.AddComment(new Comment("Admin", "Please subscribe."));


            video3.AddComment(new Comment("Student1", "Very helpful."));
            video3.AddComment(new Comment("DevNewbie", "Can you learn Java next?"));
            video3.AddComment(new Comment("Expert", "Great path."));


            videoList.Add(video1);
            videoList.Add(video2);
            videoList.Add(video3);


            Console.WriteLine("=== YouTube Product Awareness Tracker ===\n");


            foreach (Video video in videoList)
            {
                Console.WriteLine($"Video Title: {video.Title}");
                Console.WriteLine($"Author:      {video.Author}");
                Console.WriteLine($"Length:      {video.LengthSeconds} seconds");
                Console.WriteLine($"Comments:    {video.GetCommentCount()}");
                Console.WriteLine("--- Comments ---");


                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"  [{comment.CommenterName}]: {comment.CommentText}");
                }


                Console.WriteLine();
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}