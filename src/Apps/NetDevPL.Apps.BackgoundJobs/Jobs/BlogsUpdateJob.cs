using System;
using System.Linq;
using NetDevPL.Features.Blogs;
using NetDevPL.Infrastructure.Services;
using NetDevPL.Infrastructure.SharedKernel;
using Quartz;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class BlogsUpdateJob : IJob
    {
        private readonly IJsonReader _jsonReader;
        
        public BlogsUpdateJob() : this(new JsonReader()) { }

        internal BlogsUpdateJob(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public void Execute(IJobExecutionContext context)
        {
            var blogsConfig = _jsonReader.ReadAll<Blog>("blogsConfig.json");

            BlogDataProvider blogDataProvider = new BlogDataProvider();

            var blogs = blogDataProvider.GetDataFromRss(blogsConfig);

            BlogDataSnapshot snapshot = BlogDataSnapshot.Create();
            snapshot.Blogs = blogs;

            OrderBlogsByNewestPostsPosts(snapshot);

            Repository repository = new Repository();
            repository.Add(snapshot);

            Logger.Info(string.Format("Added/updated: {0} blog posts", blogs.SelectMany(b => b.BlogPosts).Count()));
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
                return DateTime.MinValue;
            });
        }
    }
}