using System.Collections.Generic;
using System.Linq;
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
                var blogPosts = rssData.Select(item => new BlogPost { Title = item.Title.Text, Url = item.Id, PublishDate = item.PublishDate.UtcDateTime });

                blog.BlogPosts = blogPosts;
            }
        
            return blogs;
        }
    }
}
