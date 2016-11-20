using System;
using System.Linq;
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
                var posts = _facebookDataRepository.PostsGetList();

                return View["facebookPosts", new FacebookPostsViewModel(posts)];
            };

            Get["/facebook-karma"] = parameters =>
            {
                var karma = new NetDevPL.Features.Reporting.FacebookStats().UserKarma();

                return String.Join("<br/>", karma.Take(100).Select(k => k.Name + " " + k.KarmaPoints));
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
