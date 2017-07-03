using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Security;
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

                return View["facebookPosts", new FacebookPostsViewModel("Posty z Facebooka", posts, Request.Url)];
            };

            Get["/facebook/karma"] = parameters =>
            {
                this.RequiresAuthentication();
                var karma = new NetDevPL.Features.Reporting.FacebookStats().UserKarma();

                return string.Join("<br/>", karma.Take(100).Select(k => k.Name + " " + k.KarmaPoints));
            };

            Get["/facebook/top/{year}/{month?}"] = parameters =>
            {
                var now = DateTime.Now;

                int year = GetValueFromDynamicOrDefault(parameters, "year", now.Year);
                year = (year < 2015 || year > now.Year) ? now.Year : year;
                int month = GetValueFromDynamicOrDefault(parameters, "month", -1);
                month = ((month < 1 || month > 12) && month != -1) ? -1 : month;

                //whole year
                if (month == -1)
                {
                    var firstDay = new DateTime(year, 1, 1);
                    var lastDay = firstDay.AddMonths(12).AddMilliseconds(-1);

                    return GetPostsForPeriod($"Top posty z Facebooka z roku {year}", firstDay, lastDay);
                }
                else
                {
                    var firstDay = new DateTime(year, month, 1);
                    var lastDay = firstDay.AddMonths(1).AddMilliseconds(-1);

                    return GetPostsForPeriod($"Top posty z Facebooka z okresu {firstDay:yyyy-MM-dd} - {lastDay:yyyy-MM-dd}", firstDay, lastDay);
                }
            };

            Get["/facebook/tag/{tag}"] = parameters =>
            {
                return GetPostsWithTag("Posty z tagiem '" + parameters.tag + "'", parameters.tag);
            };
        }

        private int GetValueFromDynamicOrDefault(dynamic dynamidObj, string propertyName, int defaultValue)
        {
            try
            {
                var dict = (IDictionary<String, object>)dynamidObj;
                if (dict.ContainsKey(propertyName))
                {
                    return Int32.Parse(dict[propertyName].ToString());
                }
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
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