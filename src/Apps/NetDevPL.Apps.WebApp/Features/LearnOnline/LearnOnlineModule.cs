using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;

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
        public List<WebsiteRecordWithTitleAndDesc> GetMasteringTools()
        {
            string json = File.ReadAllText("Features/LearnOnline/toolsMastering.json");
            var toolMasterings = JsonConvert.DeserializeObject<List<WebsiteRecordWithTitleAndDesc>>(json);
            
            return toolMasterings.ToList();
        }

        public List<WebsiteRecordWithTitleAndDesc> GetProgrammingChallenges()
        {
            string json = File.ReadAllText("Features/LearnOnline/programmingChallenges.json");
            var challenges = JsonConvert.DeserializeObject<List<WebsiteRecordWithTitleAndDesc>>(json);
            
            return challenges.ToList();
        }
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