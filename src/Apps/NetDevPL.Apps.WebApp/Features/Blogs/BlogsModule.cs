using Nancy;
using NetDevPL.Features.Blogs;

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

                return View["blogList", new BlogsViewModel(blogs, Request.Url)];
            };
        }
    }
}