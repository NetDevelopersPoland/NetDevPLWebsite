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
            var data = sut.FetchDataFromFacebook();

            Assert.NotEmpty(data);

            var firstElement = data[0];
            Assert.NotNull(firstElement.Content);
            Assert.NotNull(firstElement.CreatorId);
            Assert.NotNull(firstElement.ExternalKey);
            Assert.True(firstElement.Likes > 0);
        }
    }
}