using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Security;
using NetDevPL.Features.Facebook;

namespace NetDevPLWeb.Features.Facebook
{
    public sealed class FacebookModule : NancyModule
    {
        readonly Repository facebookDataRepository = new Repository();

        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
                var posts = facebookDataRepository.PostsGetList(PostFilter.Empty);

                return View["facebookPosts", new FacebookPostsViewModel("Posty z Facebooka", posts, Request.Url)];
            };

            Get["/facebook/karma"] = parameters =>
            {
                this.RequiresAuthentication();
                var karma = new NetDevPL.Features.Reporting.FacebookStats().UserKarma();

                return string.Join("<br/>", karma.Take(100).Select(k => k.Name + " " + k.Karma + " (" + k.LinesCount + "+" + k.CommentsCount + ")"));
            };

            Get["/facebook/top/{year:year}"] = parameters =>
            {
                int year = parameters.year;
                //whole year

                var firstDay = new DateTime(year, 1, 1);
                var lastDay = firstDay.AddMonths(12).AddMilliseconds(-1);

                return GetPostsForPeriod($"Top posty z Facebooka z roku {year}", firstDay, lastDay);
            };

            Get["/facebook/top/{year:year}/{month:month}"] = parameters =>
            {
                int month = parameters.month;
                int year = parameters.year;

                var firstDay = new DateTime(year, month, 1);
                var lastDay = firstDay.AddMonths(1).AddMilliseconds(-1);

                return GetPostsForPeriod($"Top posty z Facebooka z okresu {firstDay:yyyy-MM-dd} - {lastDay:yyyy-MM-dd}", firstDay, lastDay);

            };

            Get["/facebook/tag/{tag}"] = parameters =>
            {
                string tag = parameters.tag;
                return GetPostsWithTag("Posty z tagiem '" + tag + "'", tag);
            };
        }

        private dynamic GetPostsWithTag(string pageName, string tag)
        {
            var filter = new PostFilter
            {
                Tag = tag,
                SortingExpression = post => post.CreateDate,
                SortingDirection = SortDirection.Descending
            };

            var posts = facebookDataRepository.PostsGetList(filter);

            return View["facebookPosts", new FacebookPostsViewModel(pageName, posts, Request.Url)];
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

            return View["facebookPosts", new FacebookPostsViewModel(pageName, posts, Request.Url)];
        }
    }
}