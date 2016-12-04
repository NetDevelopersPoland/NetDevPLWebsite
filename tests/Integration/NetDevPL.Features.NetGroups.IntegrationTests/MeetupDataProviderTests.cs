using System.Collections.Generic;
using Xunit;

namespace NetDevPL.Features.NetGroups.IntegrationTests
{
    public class MeetupDataProviderTests
    {
        private MeetupDataProvider sut;

        [Fact(Skip = "Personal meetup key needs to be provided")]
        public void ShouldFetchDataFromMeetup()
        {
            NetGroup group = new NetGroup {MeetupName = "wrocnet", City = "Wrocław"};
            var data = sut.GetDataFromMeetupPage(new List<NetGroup> {group});

            Assert.NotEmpty(data);
        }

        [Fact]
        public void DummyTest()
        {
            NetGroup group = new NetGroup {MeetupName = "wrocnet", City = "Wrocław"};
            Assert.Same(group.City, "Wrocław");
        }
    }
}