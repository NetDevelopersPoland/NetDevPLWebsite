using NetDevPLWeb.Features.Facebook;
using NetDevPLWeb.Features.Facebook.DataProvider;
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
                repo.AddOrUpdate(post);
            }
        }
    }
}