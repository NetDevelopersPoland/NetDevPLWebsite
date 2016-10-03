using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using NetDevPL.Features.Blogs;
using Repository = NetDevPL.Features.Blogs.Repository;

namespace NetDevPLWeb.Features.Blogs
{
    public class BlogsModule : NancyModule
    {
        private readonly Repository _repository;

        public BlogsModule(Repository repository)
        {
            _repository = repository;
            
            Get["/blogs"] = parameters =>
            {
                var blogs = _repository.GetBlogs();

                return View["blogList", new BlogsViewModel(blogs)];
            };
        }      
    }

    public class BlogsViewModel
    {
        public BlogsViewModel(BlogDataSnapshot snapshot)
        {
            BlogsList = snapshot.Blogs ?? Enumerable.Empty<Blog>();
            LastUpdate = snapshot.SnapshotDate;
        }

        public IEnumerable<Blog> BlogsList { get; private set; }
        public DateTime LastUpdate { get; set; }
    }
}