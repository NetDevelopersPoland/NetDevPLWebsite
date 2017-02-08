using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.OfflineEvents
{
    public class ConferencesListViewModel : BaseViewModel
    {
        public ConferencesListViewModel(List<Conference> conferences, Url url) : base(url)
        {
            Conferences = conferences;
        }

        public List<Conference> Conferences { get; set; }
    }
}