using Gmtl.HandyLib;
using NetDevPL.Features.Facebook;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookPostsViewModel
    {
        public FacebookPostsViewModel(string pageName, HLListPage<FacebookPost> posts)
        {
            Posts = posts;
            PageTitle = pageName;
        }

        public HLListPage<FacebookPost> Posts { get; set; }

        public string PageTitle { get; set; }
    }
}