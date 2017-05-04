using NetDevPLWeb;
using NetDevPLWeb.Features.ConferenceVideos;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.ConferenceVideos
{
    public class ConferenceVideosSourceTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void GetMasteringTools_ReturnsAllElements()
        {
            // Arrange
            var data = _fixture.Create<ConferenceVideo[]>();
            IJsonReader reader = Substitute.For<IJsonReader>();
            reader.ReadAll<ConferenceVideo>(Arg.Any<string>()).Returns(data);

            // Act
            var source = new ConferenceVideosSource(reader);

            // Assert
            Assert.Equal(data, source.GetVideos());
        }
    }
}
