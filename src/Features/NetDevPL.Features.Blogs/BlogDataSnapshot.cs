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
}