using Nancy;
using NetDevPLWeb.Features.Resources;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Resources
{

    public class ResourcesViewModelTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Ctor_AssignsValues()
        {
            // Arrange
            var resources = _fixture.Create<Resource[]>();
            var url = _fixture.Create<Url>();

            // Act
            var vm = new ResourcesViewModel(resources, url);

            // Assert
            Assert.Equal(resources, vm.ResourcesList);
            Assert.Equal(url, vm.Url);
        }
    }
}
