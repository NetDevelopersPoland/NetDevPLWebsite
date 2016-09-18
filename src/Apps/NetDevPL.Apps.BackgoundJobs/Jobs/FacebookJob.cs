using NetDevPLWeb.Features.Facebook;
using NetDevPLWeb.Features.Facebook.DataProvider;
using NetDevPLWeb.SharedKernel;
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