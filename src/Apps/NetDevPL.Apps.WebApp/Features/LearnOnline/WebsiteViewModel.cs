using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class WebsiteViewModel : BaseViewModel
    {
        public WebsiteViewModel(ICollection<Website> toolMastering, ICollection<Website> programmingChallenges, Url url) : base(url)
        {
            ToolMastering = toolMastering;
            ProgrammingChallenges = programmingChallenges;
        }

        public ICollection<Website> ToolMastering { get; }
        public ICollection<Website> ProgrammingChallenges { get; }
    }

    public class Website
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}