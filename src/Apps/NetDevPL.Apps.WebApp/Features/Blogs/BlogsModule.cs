using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using NetDevPL.Infrastructure.Helpers;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Blogs
{
    public class BlogsModule : NancyModule
    {
        private readonly BlogComponent _blogComponent;
        private readonly BlogSource _source;

        public BlogsModule(BlogComponent blogComponent, BlogSource source)
        {
            _blogComponent = blogComponent;
            _source = source;

            Get["/blogs"] = parameters =>
            {
                var blogs = _source.GetBlogs();
                var blogListViewModel = _blogComponent.CreateBlogViewModelList(blogs);

                return View["blogList", blogListViewModel];
            };
        }      
    }

    public class BlogSource
    {
        public List<Blog> GetBlogs()
        {
            var blogs = JsonReaderHelper.ReadObjectListFromJson<Blog>("Features/Blogs/blogs.json");
            
            //Randomize order to not favorize any
            return blogs.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }

    public class Blog
    {
        public string Url { get; set; }
        public string Rss { get; set; }
        public string Title { get; set; }
    }
}