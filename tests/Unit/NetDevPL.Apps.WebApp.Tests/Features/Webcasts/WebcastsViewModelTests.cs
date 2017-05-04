using Nancy;
using NetDevPLWeb.Features.WebCasts;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Webcasts
{
    public class WebcastsViewModelTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Ctor_AssignsValues()
        {
            // Arrange
            var webcasts = _fixture.Create<Webcast[]>();
            var url = _fixture.Create<Url>();

            // Act
            var vm = new WebcastsViewModel(webcasts, url);

            // Assert
            Assert.Equal(webcasts, vm.Webcasts);
            Assert.Equal(url, vm.Url);
        }
    }
}
