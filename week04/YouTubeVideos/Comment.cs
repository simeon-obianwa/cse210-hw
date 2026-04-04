using System;

namespace YouTubeTracker
{
    /// I applied abstraction to hide internal storage and exposing only necessary properties.
    public class Comment
    {
        public string CommenterName { get; set; }

        public string CommentText { get; set; }

        /// To initialize a new instance of the comment class with the specified name and text.
        /// <param name="name">The name of the commenter.</param>
        /// <param name="text">The text of the comment.</param>
        public Comment(string name, string text)
        {
            CommenterName = name;
            CommentText = text;
        }
    }
}