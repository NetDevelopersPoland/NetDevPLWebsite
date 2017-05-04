using Nancy;
using NetDevPLWeb.Features.LearnOnline;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.LearnOnline
{

    public class LearnOnlineListViewModelTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Ctor_AssignsValues()
        {
            // Arrange
            var toolMastering = _fixture.Create<Website[]>();
            var programmingChallenges = _fixture.Create<Website[]>();
            var url = _fixture.Create<Url>();

            // Act
            var vm = new WebsiteViewModel(toolMastering, programmingChallenges, url);

            // Assert
            Assert.Equal(toolMastering, vm.ToolMastering);
            Assert.Equal(programmingChallenges, vm.ProgrammingChallenges);
            Assert.Equal(url, vm.Url);
        }
    }
}
