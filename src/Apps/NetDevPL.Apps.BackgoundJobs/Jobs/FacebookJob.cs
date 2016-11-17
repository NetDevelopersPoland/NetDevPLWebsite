using System;
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
            Repository repository = new Repository();

            foreach (var post in provider.FetchPostsFromFacebook())
            {
                Logger.Info(String.Format("Facebook postId added/updated: {0}", post.ExternalKey));
                repository.PostAddOrUpdate(post);

                UpdatePostDetails(post, provider, repository);
            }
        }

        private void UpdatePostDetails(FacebookPost post, FacebookDataProvider provider, Repository repository)
        {
            var likesAndUsers=provider.GetLikesAndUsersForPostFromFacebook(post.ExternalKey);

            foreach (var like in likesAndUsers.Item1)
            {
                repository.LikeAdd(like);
            }

            foreach (var user in likesAndUsers.Item2)
            {
                repository.UserAddOrUpdate(user);
            }
        }
    }
}