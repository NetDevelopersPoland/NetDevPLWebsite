using System.Collections.Generic;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.OfflineEvents
{
    public class ConferencesListViewModel : BaseViewModel
    {
        public ConferencesListViewModel(List<Conference> conferences)
        {
            Conferences = conferences;
        }

        public List<Conference> Conferences { get; set; }
    }
}