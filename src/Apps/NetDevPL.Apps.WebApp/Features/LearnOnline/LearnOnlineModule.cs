using Nancy;
using NetDevPL.Infrastructure.Services;

namespace NetDevPLWeb.Features.LearnOnline
{
    public sealed class LearnOnlineModule : NancyModule
    {
        public LearnOnlineModule(IJsonReader repository)
        {
            var source = new LearnOnlineSource(repository);

            Get["/learnOnline"] = parameters =>
            {
                var toolsMastering = source.GetMasteringTools();
                var programmingChallenges = source.GetProgrammingChallenges();

                return View["learnOnlineList", new WebsiteViewModel(toolsMastering, programmingChallenges, Request.Url)];
            };
        }
    }
}