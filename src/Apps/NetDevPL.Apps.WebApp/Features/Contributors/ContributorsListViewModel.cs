using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Contributors
{
    public class ContributorsListViewModel : BaseViewModel
    {
        public ContributorsListViewModel(List<Contributor> contributors, Url url) : base(url)
        {
            Contributors = contributors;
        }

        public List<Contributor> Contributors { get; set; }
    }
}