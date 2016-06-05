using System;
using Gmtl.HandyLib;
using Nancy;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookModule : NancyModule
    {
        Repository facebookDataRepository = new Repository();

        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
                var posts = facebookDataRepository.GetList();

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