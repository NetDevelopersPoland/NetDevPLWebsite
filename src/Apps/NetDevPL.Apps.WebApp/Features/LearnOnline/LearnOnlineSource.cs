using System.Collections.Generic;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class LearnOnlineSource
    {
        public List<WebsiteRecordWithTitleAndDesc> GetMasteringTools() => JsonReaderHelper.ReadObjectListFromJson<WebsiteRecordWithTitleAndDesc>("Features/LearnOnline/toolsMastering.json");

        public List<WebsiteRecordWithTitleAndDesc> GetProgrammingChallenges() => JsonReaderHelper.ReadObjectListFromJson<WebsiteRecordWithTitleAndDesc>("Features/LearnOnline/programmingChallenges.json");
    }
}