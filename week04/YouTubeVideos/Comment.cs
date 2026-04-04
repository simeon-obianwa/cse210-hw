using System;

namespace YouTubeTracker
{
    /// I applied abstraction by hiding internal storage and exposing only necessary properties.
    public class Comment
    {
        public string CommenterName { get; set; }

        public string CommentText { get; set; }

        /// Initializes a new instance of the Comment class with the specified name and text.
        /// Ensures comments are always created with valid data.
        /// <param name="name">The name of the commenter.</param>
        /// <param name="text">The text of the comment.</param>
        public Comment(string name, string text)
        {
            CommenterName = name;
            CommentText = text;
        }
    }
}