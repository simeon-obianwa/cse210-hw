using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    /// I applied abstraction by keeping the internal comment list private.
    public class Video
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int LengthSeconds { get; set; }

        private List<Comment> _comments;


        /// <param name="title">The title of the video.</param>
        /// <param name="author">The author of the video.</param>
        /// <param name="lengthSeconds">The length of the video in seconds.</param>
        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
            _comments = new List<Comment>();
        }

        ///To add a comment to the video's comment collection.
        /// <param name="comment">The comment to add.</param>
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        /// To returns the total number of comments on the video.
        /// <returns>The count of comments.</returns>
        public int GetCommentCount()
        {
            return _comments.Count;
        }


        /// To get the list of comments for display purposes.
        public List<Comment> Comments
        {
            get { return _comments; }
        }
    }
}