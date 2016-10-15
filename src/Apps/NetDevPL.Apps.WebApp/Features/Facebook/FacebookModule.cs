using Gmtl.HandyLib;
using Nancy;
using NetDevPL.Features.Facebook;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookModule : NancyModule
    {
        readonly Repository _facebookDataRepository = new Repository();

        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
                var posts = _facebookDataRepository.GetList();

                return View["facebookPosts", new FacebookPostsViewModel(posts)];
            };
        }
    }

    public class FacebookPostsViewModel
    {
        public FacebookPostsViewModel(HLListPage<FacebookPost> posts)
        {
            Posts = posts;
        }

        public HLListPage<FacebookPost> Posts { get; set; }
    }
}