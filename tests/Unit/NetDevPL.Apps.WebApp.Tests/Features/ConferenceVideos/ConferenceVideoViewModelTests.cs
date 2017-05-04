using Nancy;
using NetDevPLWeb.Features.ConferenceVideos;
using Ploeh.AutoFixture;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.ConferenceVideos
{

    public class ConferenceVideoViewModelTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Ctor_AssignsValues()
        {
            // Arrange
            var videos = _fixture.Create<ConferenceVideo[]>();
            var url = _fixture.Create<Url>();

            // Act
            var vm = new ConferenceVideosViewModel(videos, url);

            // Assert
            Assert.Equal(videos, vm.Videos);
            Assert.Equal(url, vm.Url);
        }
    }
}
