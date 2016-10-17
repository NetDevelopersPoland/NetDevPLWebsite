using System;
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

            Repository repository = new Repository();
            repository.Add(snapshot);

            Logger.Info(String.Format("Added/updated: {0} blog posts", blogs.SelectMany(b => b.BlogPosts).Count()));
        }
    }
}