using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Using the Comment Class to track the name of the commenter and the text.
    // Applied abstraction to hides the internal storage of the data, exposes only the necessary properties.         

    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        // Using constructor to ensure comments are always created with valid data
        public Comment(string name, string text)
        {
            CommenterName = name;
            CommentText = text;
        }
    }

    // Applied abstraction at the Video Class to make the internal list of comments private.
    // To ensure External code cannot modify the list directly.
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthSeconds { get; set; }

        // Using Private list to hide the implementation detail from the user of this class
        private List<Comment> _comments;

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
            _comments = new List<Comment>(); 
        }

        // Method used to add a comment. 
        // List not made known to the public.
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Method used to return count. 
        // How we count comment not made known to the public. 
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        // This property allow reading the comments for the purpose of display.
        public List<Comment> Comments
        {
            get { return _comments; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List created to hold our Video objects
            List<Video> videoList = new List<Video>();

            // Create 3-4 Videos and set values
            Video video1 = new Video("Understanding Abstraction", "CodeMaster", 345);
            Video video2 = new Video("Top 20 Dos", "TechGuru", 620);
            Video video3 = new Video("C# lesson for Beginners", "SimeonDevs", 1205);

            // Video 1 Comments, Adding 3-4 Comments to each video
            video1.AddComment(new Comment("Nick", "Great explanation!"));
            video1.AddComment(new Comment("Gab", "I finally get it."));
            video1.AddComment(new Comment("Rose", "Thanks for sharing."));

            // Video 2 Comments
            video2.AddComment(new Comment("SeeDove54", "Where are the dogs?"));
            video2.AddComment(new Comment("JohnFan", "So great!"));
            video2.AddComment(new Comment("Viewer1", "Nice video."));
            video2.AddComment(new Comment("Admin", "Please subscribe."));

            // Video 3 Comments
            video3.AddComment(new Comment("Student1", "Very helpful."));
            video3.AddComment(new Comment("DevNewbie", "Can you learn Java next?"));
            video3.AddComment(new Comment("Expert", "Great path."));

            // Add videos in the list
            videoList.Add(video1);
            videoList.Add(video2);
            videoList.Add(video3);

            // List iteration and information display 
            Console.WriteLine("=== YouTube Product Awareness Tracker ===\n");

            foreach (Video video in videoList)
            {
                // Display Video Details
                Console.WriteLine($"Video Title: {video.Title}");
                Console.WriteLine($"Author:      {video.Author}");
                Console.WriteLine($"Length:      {video.LengthSeconds} seconds");
                Console.WriteLine($"Comments:    {video.GetCommentCount()}"); 
                Console.WriteLine("--- Comments ---");

                // Individual Comments Display
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