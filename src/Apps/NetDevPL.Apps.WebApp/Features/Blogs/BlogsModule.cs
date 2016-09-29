using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Blogs
{
    public class BlogsModule : NancyModule
    {
        readonly BlogSource _source = new BlogSource();

        public BlogsModule()
        {
            Get["/blogs"] = parameters =>
            {
                var blogs = _source.GetBlogs();
                return View["blogList", new BlogListViewModel(blogs)];
            };
        }
    }

    public class BlogSource
    {
        public List<Blog> GetBlogs()
        {
            string json = File.ReadAllText("Features/Blogs/blogs.json");
            var blogs = JsonConvert.DeserializeObject<List<Blog>>(json);

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

    public class BlogListViewModel
    {
        public BlogListViewModel(List<Blog> blogs)
        {
            Blogs = blogs;
        }

        public List<Blog> Blogs { get; set; }
    }
}