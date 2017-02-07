using System;
using System.Linq;
using Nancy;
using NetDevPL.Features.Facebook;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookModule : NancyModule
    {
        readonly Repository facebookDataRepository = new Repository();

        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
                var posts = facebookDataRepository.PostsGetList(PostFilter.Empty);
                
                return View["facebookPosts", new FacebookPostsViewModel("Posty z Facebooka", posts)];
            };

            Get["/facebook/karma"] = parameters =>
            {
                var karma = new NetDevPL.Features.Reporting.FacebookStats().UserKarma();

                return string.Join("<br/>", karma.Take(100).Select(k => k.Name + " " + k.KarmaPoints));
            };

            Get["/facebook/top-last-month"] = parameters =>
            {
                var lastMonth = DateTime.Now.AddMonths(-1);
                var firstDay = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                var lastDay = firstDay.AddMonths(1).AddMilliseconds(-1);

                return GetPostsForPeriod("Top posty z Facebooka z ostatniego miesiąca", firstDay, lastDay);
            };

            Get["/facebook/top-current-year"] = parameters =>
            {
                var firstDay = new DateTime(DateTime.Now.Year, 1, 1);
                var lastDay = firstDay.AddYears(1).AddMilliseconds(-1);

                return GetPostsForPeriod("Top posty z Facebooka z ostatniego roku", firstDay, lastDay);
            };
        }

        private dynamic GetPostsForPeriod(string pageName, DateTime startDate, DateTime endDate)
        {
            var filter = new PostFilter
            {
                StartDate = startDate,
                EndDate = endDate,
                SortingExpression = post => post.Likes,
                SortingDirection = SortDirection.Descending
            };
            var posts = facebookDataRepository.PostsGetList(filter);

            return View["facebookPosts", new FacebookPostsViewModel(pageName, posts)];
        }
    }
}