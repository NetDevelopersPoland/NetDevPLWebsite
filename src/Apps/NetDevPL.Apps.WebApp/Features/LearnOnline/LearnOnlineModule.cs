using System.Collections.Generic;
using Nancy;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class LearnOnlineModule : NancyModule
    {
        readonly LearnOnlineSource _source = new LearnOnlineSource();

        public LearnOnlineModule()
        {
            Get["/learnOnline"] = parameters =>
            {
                var toolsMastering = _source.GetMasteringTools();
                var programmingChallenges = _source.GetProgrammingChallenges();

                return View["learnOnlineList", new LearOnlineListViewModel(toolsMastering, programmingChallenges)];
            };
        }
    }

    public class LearnOnlineSource
    {
        public List<WebsiteRecordWithTitleAndDesc> GetMasteringTools() => JsonReaderHelper.ReadObjectListFromJson<WebsiteRecordWithTitleAndDesc>("Features/LearnOnline/toolsMastering.json");

        public List<WebsiteRecordWithTitleAndDesc> GetProgrammingChallenges() => JsonReaderHelper.ReadObjectListFromJson<WebsiteRecordWithTitleAndDesc>("Features/LearnOnline/programmingChallenges.json");
    }

    public class WebsiteRecordWithTitleAndDesc
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class LearOnlineListViewModel
    {
        public LearOnlineListViewModel(List<WebsiteRecordWithTitleAndDesc> toolMastering, List<WebsiteRecordWithTitleAndDesc> programmingChallenges
            )
        {
            ToolMastering = toolMastering;
            ProgrammingChallenges = programmingChallenges;
        }

        public List<WebsiteRecordWithTitleAndDesc> ToolMastering { get; private set; }
        public List<WebsiteRecordWithTitleAndDesc> ProgrammingChallenges{ get; private set; }
    }
}