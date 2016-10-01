using System.Collections.Generic;

namespace NetDevPLWeb.Features.Blogs.ViewModels
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
    }
}
