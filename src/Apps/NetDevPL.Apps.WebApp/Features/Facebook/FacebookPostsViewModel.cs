using System.Collections.Generic;
using NetDevPL.Features.Facebook;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookPostsViewModel
    {
        public FacebookPostsViewModel(string pageName, List<FacebookPost> posts)
        {
            Posts = posts;
            PageTitle = pageName;
        }

        public List<FacebookPost> Posts { get; set; }

        public string PageTitle { get; set; }
    }
}