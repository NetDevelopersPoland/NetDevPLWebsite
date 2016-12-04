using System.Collections.Generic;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class LearOnlineListViewModel
    {
        public LearOnlineListViewModel(List<WebsiteRecordWithTitleAndDesc> toolMastering, List<WebsiteRecordWithTitleAndDesc> programmingChallenges
            )
        {
            ToolMastering = toolMastering;
            ProgrammingChallenges = programmingChallenges;
        }

        public List<WebsiteRecordWithTitleAndDesc> ToolMastering { get; private set; }
        public List<WebsiteRecordWithTitleAndDesc> ProgrammingChallenges { get; private set; }
    }

    public class WebsiteRecordWithTitleAndDesc
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}