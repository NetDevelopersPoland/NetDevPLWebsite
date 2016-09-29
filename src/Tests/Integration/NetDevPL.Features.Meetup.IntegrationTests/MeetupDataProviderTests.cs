using System.Configuration;
using Xunit;

namespace NetDevPL.Features.Meetup.IntegrationTests
{
    public class MeetupDataProviderTests
    {
        private MeetupDataProvider sut;
        
        public MeetupDataProviderTests()
        {
            //In order to run those tests configuration MeetupApiKey value must be set
            //Obtain one at: https://secure.meetup.com/meetup_api/key/
            Assert.NotNull(ConfigurationManager.AppSettings["MeetupApiKey"]);
            sut = new MeetupDataProvider();
        }

        [Fact(Skip = "Personal meetup key needs to be provided")]
        public void ShouldFetchDataFromMeetup()
        {
            var data = sut.GetDataFromMeetupPage();

            Assert.NotEmpty(data);
        }
    }
}