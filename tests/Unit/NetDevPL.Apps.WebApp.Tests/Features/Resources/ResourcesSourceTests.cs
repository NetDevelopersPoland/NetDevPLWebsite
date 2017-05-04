using NetDevPL.Infrastructure.Services;
using NetDevPLWeb.Features.Resources;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Resources
{
    public class ResourcesSourceTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void GetMasteringTools_ReturnsAllElements()
        {
            // Arrange
            var data = _fixture.Create<Resource[]>();
            IJsonReader reader = Substitute.For<IJsonReader>();
            reader.ReadAll<Resource>(Arg.Any<string>()).Returns(data);

            // Act
            var source = new ResourcesSource(reader);

            // Assert
            Assert.Equal(data, source.GetResources());
        }
    }
}
