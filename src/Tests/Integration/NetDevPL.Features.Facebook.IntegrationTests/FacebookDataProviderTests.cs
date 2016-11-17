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
            var testPost = data[0];

            var result = sut.GetLikesAndUsersForPostFromFacebook(testPost.ExternalKey);

            Assert.NotNull(result);
            Assert.True(result.Item1.Count > 0);
            Assert.True(result.Item2.Count > 0);
            Assert.True(result.Item1.Count == result.Item2.Count);

            var firstLike = result.Item1[0];
            Assert.NotEmpty(firstLike.PostId);
            Assert.NotEmpty(firstLike.UserId);

            var firstUser = result.Item2[0];
            Assert.NotEmpty(firstUser.Id);
            Assert.NotEmpty(firstUser.Name);
        }
    }
}