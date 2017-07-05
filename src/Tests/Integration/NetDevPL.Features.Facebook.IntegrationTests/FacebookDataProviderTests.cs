using System.Configuration;
using NetDevPL.Features.Facebook.DataProvider;
using Xunit;

namespace NetDevPL.Features.Facebook.IntegrationTests
{
    public class FacebookDataProviderTests
    {
        private readonly FacebookDataProvider sut;

        public FacebookDataProviderTests()
        {
            //TODO fix for appveyor tests
            Assert.NotNull(ConfigurationManager.AppSettings["FacebookAccessToken"]);
            sut = new FacebookDataProvider();
        }

        [Fact(Skip = "Personal FacebookAccessToken key needs to be provided")]
        public void ShouldFetchDataFromFacebookGroupPage()
        {
            var data = sut.FetchPostsFromFacebook();

            Assert.NotEmpty(data);

            var firstElement = data[0];
            Assert.NotNull(firstElement.Content);
            Assert.NotNull(firstElement.CreatorId);
            Assert.NotNull(firstElement.ExternalKey);
            Assert.True(firstElement.Likes > 0);
        }

        [Fact(Skip = "Personal FacebookAccessToken key needs to be provided")]
        public void ShouldFetchDataForSingleFacebookPost()
        {
            var data = sut.FetchPostsFromFacebook();

            bool hasAtLeastOneLike = false;
            bool hasAtLeastOneComment = false;
            bool hasAtLeastOneUser = false;

            foreach (var post in data)
            {
                var result = sut.GetLikesAndUsersForPostFromFacebook(post.ExternalKey);

                Assert.NotNull(result);
                hasAtLeastOneLike |= (result.Item1.Count > 0);
                hasAtLeastOneComment |= (result.Item2.Count > 0);
                hasAtLeastOneUser |= (result.Item3.Count > 0);
            }

            Assert.True(hasAtLeastOneComment);
            Assert.True(hasAtLeastOneLike);
            Assert.True(hasAtLeastOneUser);
        }
    }
}