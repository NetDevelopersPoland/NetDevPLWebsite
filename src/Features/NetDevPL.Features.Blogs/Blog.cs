using System.Collections.Generic;

namespace NetDevPL.Features.Blogs
{
    public class Blog
    {
        public string Url { get; set; }
        public string Rss { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// By default an url for a post is read from <seealso cref="System.ServiceModel.Syndication.SyndicationItem.Id"/> property.
        /// If this property is set, it will be read from a given index in the
        /// <seealso cref="System.ServiceModel.Syndication.SyndicationItem.Links"/> collection. 
        /// </summary>
        public int? IndexOfLinkToPost { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}