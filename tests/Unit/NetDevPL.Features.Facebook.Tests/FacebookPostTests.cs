using Xunit;

namespace NetDevPL.Features.Facebook.Tests
{
    public class FacebookPostTests
    {
        private FacebookPost sut;

        public FacebookPostTests()
        {
            sut = new FacebookPost();
        }

        [Theory]
        [InlineData("test http://test.com", "test <a href=\"http://test.com\" target=\"_new\">http://test.com</a>")]
        [InlineData("test https://test.com", "test <a href=\"https://test.com\" target=\"_new\">https://test.com</a>")]
        [InlineData("test http://test.com/", "test <a href=\"http://test.com/\" target=\"_new\">http://test.com/</a>")]
        [InlineData("test http://test.com/index.html", "test <a href=\"http://test.com/index.html\" target=\"_new\">http://test.com/index.html</a>")]
        [InlineData("test http://test.com/index.html?count=10", "test <a href=\"http://test.com/index.html?count=10\" target=\"_new\">http://test.com/index.html?count=10</a>")]
        public void ProvidedContentWithHttpAddress_ShouldMakeHtmlTagOfIt(string content, string expectedOutput)
        {
            sut.Content = content;

            Assert.Equal(expectedOutput, sut.ContentWithHyperLinks);
        }

        [Theory]
        [InlineData("Sample information")]
        [InlineData("Sample information http address")]
        [InlineData("Sample information http index.html")]
        public void ProvidedContentWithoutHttpAddress_ShouldKeepSameContentAfterExecuting_MakeTyperLinksInContent(string content)
        {
            sut.Content = content;

            Assert.Equal(content, sut.ContentWithHyperLinks);
        }
    }
}