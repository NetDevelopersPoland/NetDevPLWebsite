using System.Collections.Generic;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Contributors
{
    public class ContributorsListViewModel : BaseViewModel
    {
        public ContributorsListViewModel(List<Contributor> contributors)
        {
            Contributors = contributors;
        }

        public List<Contributor> Contributors { get; set; }
    }
}