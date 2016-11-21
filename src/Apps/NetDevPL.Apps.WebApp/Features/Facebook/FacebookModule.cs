using System;
using System.Globalization;
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
                var posts = _facebookDataRepository.PostsGetList(PostFilter.Empty);

                return View["facebookPosts", new FacebookPostsViewModel(posts)];
            };

            Get["/facebook-karma"] = parameters =>
            {
                var karma = new NetDevPL.Features.Reporting.FacebookStats().UserKarma();

                return String.Join("<br/>", karma.Take(100).Select(k => k.Name + " " + k.KarmaPoints));
            };

            Get["/facebook/top-last-month"] = parameters =>
            {
                var lastMonth = DateTime.Now.AddMonths(-1);
                var firstDay = new DateTime(lastMonth.Year, lastMonth.Month, 1);

                var filter = new PostFilter
                {
                    StartDate = firstDay,
                    EndDate = firstDay.AddMonths(1).AddMilliseconds(-1),
                    SortingExpression = post => post.Likes,
                    SortingDirection = SortDirection.Descending
                };
                var posts = _facebookDataRepository.PostsGetList(filter);

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
