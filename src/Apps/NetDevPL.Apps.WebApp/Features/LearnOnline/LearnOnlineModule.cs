using Nancy;

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

                return View["learnOnlineList", new LearOnlineListViewModel(toolsMastering, programmingChallenges, Request.Url)];
            };
        }
    }
}