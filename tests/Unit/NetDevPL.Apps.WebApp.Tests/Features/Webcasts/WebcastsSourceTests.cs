using NetDevPL.Infrastructure.Services;
using NetDevPLWeb.Features.WebCasts;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Webcasts
{
    public class WebcastsSourceTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void GetWebcast_ReturnsAllElements()
        {
            // Arrange
            var data = _fixture.Create<Webcast[]>();
            IJsonReader reader = Substitute.For<IJsonReader>();
            reader.ReadAll<Webcast>(Arg.Any<string>()).Returns(data);

            // Act
            var source = new WebcastsSource(reader);

            // Assert
            Assert.Equal(data, source.GetWebcast());
        }
    }
}
