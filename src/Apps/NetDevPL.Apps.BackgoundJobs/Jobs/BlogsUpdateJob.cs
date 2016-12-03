using System;
using System.Collections.Generic;
using System.Linq;
using NetDevPL.Features.Blogs;
using NetDevPL.Infrastructure.Helpers;
using NetDevPL.Infrastructure.SharedKernel;
using Quartz;
using Repository = NetDevPL.Features.Blogs.Repository;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class BlogsUpdateJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var blogsConfig = JsonReaderHelper.ReadObjectListFromJson<Blog>("blogsConfig.json");

            BlogDataProvider blogDataProvider = new BlogDataProvider();

            var blogs = blogDataProvider.GetDataFromRss(blogsConfig);

            BlogDataSnapshot snapshot = BlogDataSnapshot.Create();
            snapshot.Blogs = blogs;

            OrderBlogsByNewestPostsPosts(snapshot);

            Repository repository = new Repository();
            repository.Add(snapshot);

            Logger.Info(String.Format("Added/updated: {0} blog posts", blogs.SelectMany(b => b.BlogPosts).Count()));
        }

        private void OrderBlogsByNewestPostsPosts(BlogDataSnapshot snapshot)
        {
            snapshot.Blogs = snapshot.Blogs.OrderByDescending(b =>
            {
                var newestPost = b.BlogPosts.OrderByDescending(p => p.PublishDate).FirstOrDefault();
                if (newestPost != null)
                {
                    return newestPost.PublishDate;
                }
                else
                    return DateTime.MinValue;
            });
        }
    }
}