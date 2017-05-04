using NetDevPLWeb;
using NetDevPLWeb.Features.LearnOnline;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.LearnOnline
{
    public class LearnOnlineSourceTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void GetMasteringTools_ReturnsAllElements()
        {
            // Arrange
            var data = _fixture.Create<Website[]>();
            IJsonReader reader = Substitute.For<IJsonReader>();
            reader.ReadAll<Website>(Arg.Any<string>()).Returns(data);

            // Act
            var source = new LearnOnlineSource(reader);

            // Assert
            Assert.Equal(data, source.GetMasteringTools());
        }

        [Fact]
        public void GetProgrammingChallenges_ReturnsAllElements()
        {
            // Arrange
            var data = _fixture.Create<Website[]>();
            IJsonReader reader = Substitute.For<IJsonReader>();
            reader.ReadAll<Website>(Arg.Any<string>()).Returns(data);

            // Act
            var source = new LearnOnlineSource(reader);

            // Assert
            Assert.Equal(data, source.GetMasteringTools());
        }
    }
}
