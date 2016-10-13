using System.Collections.Generic;
using System.Configuration;
using Xunit;

namespace NetDevPL.Features.NetGroups.IntegrationTests
{
    public class MeetupDataProviderTests
    {
        private MeetupDataProvider sut;

        public MeetupDataProviderTests()
        {
            //In order to run those tests configuration MeetupApiKey value must be set
            //Obtain one at: https://secure.meetup.com/meetup_api/key/

            //TODO fix for appveyor tests
            //Assert.NotNull(ConfigurationManager.AppSettings["MeetupApiKey"]);
            //sut = new MeetupDataProvider();
        }

        [Fact(Skip = "Personal meetup key needs to be provided")]
        public void ShouldFetchDataFromMeetup()
        {
            NetGroup group = new NetGroup { MeetupName = "wrocnet", City = "Wrocław" };
            var data = sut.GetDataFromMeetupPage(new List<NetGroup> { group });

            Assert.NotEmpty(data);
        }

        [Fact]
        public void DummyTest()
        {
            NetGroup group = new NetGroup { MeetupName = "wrocnet", City = "Wrocław" };
            Assert.Same(group.City, "Wrocław");
        }
    }
}