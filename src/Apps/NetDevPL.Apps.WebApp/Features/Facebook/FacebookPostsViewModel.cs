using Gmtl.HandyLib;
using NetDevPL.Features.Facebook;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookPostsViewModel : BaseViewModel
    {
        public FacebookPostsViewModel(string pageName, HLListPage<FacebookPost> posts)
        {
            Posts = posts;
            Title = pageName;
            Description = pageName;
        }

        public HLListPage<FacebookPost> Posts { get; set; }
    }
}