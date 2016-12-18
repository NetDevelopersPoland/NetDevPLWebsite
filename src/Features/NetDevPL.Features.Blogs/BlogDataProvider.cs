using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

using NetDevPL.Infrastructure.Helpers;


namespace NetDevPL.Features.Blogs
{
    public class BlogDataProvider
    {
        public IList<Blog> GetDataFromRss(IList<Blog> blogs)
        {
            foreach (var blog in blogs)
            {
                var rssData = RssProvider.GetItemsFromRss(blog.Rss);
                var blogPosts = rssData.Select(item => new BlogPost {Title = item.Title.Text, Url = GetUrl(blog, item), PublishDate = item.PublishDate.UtcDateTime});

                blog.BlogPosts = blogPosts;
            }

            return blogs;
        }

        private string GetUrl(Blog blog, SyndicationItem item)
        {
            var url = item.Id;

            if (blog.IndexOfLinkToPost.HasValue)
            {
                var index = blog.IndexOfLinkToPost.Value;
                if (item.Links != null && item.Links.Any() && index < item.Links.Count)
                    url = item.Links[index].Uri.AbsoluteUri;
            }

            return url;
        }
    }
}