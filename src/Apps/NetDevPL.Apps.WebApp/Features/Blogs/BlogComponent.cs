using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using NetDevPL.Features.Rss;
using NetDevPLWeb.Features.Blogs.ViewModels;

namespace NetDevPLWeb.Features.Blogs
{
    public class BlogComponent
    {
        private const int BlogPostsCount = 3; // TODO: put it somewhere in configuration
        private readonly RssProvider _blogRssProvider;

        public BlogComponent(RssProvider blogRssProvider)
        {
            _blogRssProvider = blogRssProvider;
        }

        public IEnumerable<BlogViewModel> CreateBlogViewModelList(IEnumerable<Blog> blogs)
        {
            return blogs.Select(blog => new BlogViewModel
            {
                Title = blog.Title,
                BlogPosts = _blogRssProvider.GetItemsFromRss(blog.Rss).Take(BlogPostsCount).Select(CreateBlogPostViewModel)
            }).ToList();
        }

        private BlogPostViewModel CreateBlogPostViewModel(SyndicationItem blogPost) // TODO: Replace it with e.g. AutoMapper in future
        {
            var blogPostViewModel = new BlogPostViewModel
            {
                Title = blogPost.Title.Text,
                Link = blogPost.Links.First().Uri.AbsoluteUri
            };

            return blogPostViewModel;
        }
    }
}
