using System;
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
        [InlineData("test https://medium.com/@akosma/being-a-developer-after-40-6-months-later-7e8c278c13a#.uqg7q4ilm", "test <a href=\"https://medium.com/@akosma/being-a-developer-after-40-6-months-later-7e8c278c13a#.uqg7q4ilm\" target=\"_new\">https://medium.com/@akosma/being-a-developer-after-40-6-months-later-7e8c278c13a#.uqg7q4ilm</a>")]
        [InlineData("test http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p", "test <a href=\"http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p\" target=\"_new\">http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p</a>")]
        [InlineData("...wydanie tejże: http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p . Przechodząca...", "...wydanie tejże: <a href=\"http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p\" target=\"_new\">http://www.empik.com/praca-z-zastanym-kodem-najlepsze-techniki-michael-feathers,p1143740022,ksiazka-p</a> . Przechodząca...")]
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

        [Theory]
        [InlineData("Sample post content", "")]
        [InlineData("Sample #post #content", "post,content")]
        [InlineData("Sample post #content", "content")]
        [InlineData("Sample post#content", "")]
        [InlineData("Sample post##content", "")]
        [InlineData("Sample post ##content", "")]
        [InlineData("Sample post # content", "")]
        [InlineData("Sample post #content#", "")]
        [InlineData("Sample post #con#tent", "")]
        [InlineData("#Sample #post #con#tent", "sample,post")]
        [InlineData("Sample #post ##content", "post")]
        public void ProvidedContentShouldExtractTags(string content, string expectedTagsCommaSeparated)
        {
            var actaulTags = String.Join(",", FacebookPost.ExtractTags(content));

            Assert.Equal(expectedTagsCommaSeparated, actaulTags);
        }
    }
}