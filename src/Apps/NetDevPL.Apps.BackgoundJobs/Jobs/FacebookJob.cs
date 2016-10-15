using NetDevPL.Features.Facebook;
using NetDevPL.Features.Facebook.DataProvider;
using NetDevPL.Infrastructure.SharedKernel;
using Quartz;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class FacebookJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            FacebookDataProvider provider = new FacebookDataProvider();
            Repository repo = new Repository();

            foreach (var post in provider.FetchDataFromFacebook())
            {
                Logger.Info("Facebook postId added/updated: " + post.ExternalKey);
                repo.AddOrUpdate(post);
            }
        }
    }
}