using System;
using System.Collections.Generic;

namespace NetDevPL.Features.Blogs
{
    /// <summary>
    ///     State of .net blogs at a certain date
    /// </summary>
    public class BlogDataSnapshot
    {
        public IEnumerable<Blog> Blogs { get; set; }

        /// <summary>
        ///     Date when snapshot was taken
        /// </summary>
        public DateTime SnapshotDate { get; set; }

        public static BlogDataSnapshot Create()
        {
            return new BlogDataSnapshot {SnapshotDate = DateTime.Now};
        }
    }

    public class Blog
    {
        public string Url { get; set; }
        public string Rss { get; set; }
        public string Title { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }

    public class BlogPost
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
    }
}