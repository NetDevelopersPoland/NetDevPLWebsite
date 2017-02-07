using System.Collections.Generic;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.WebCasts
{
    public class Webcast
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class WebcastsViewModel: BaseViewModel
    {
        public WebcastsViewModel(List<Webcast> webcasts)
        {
            WebcastsList = webcasts;
        }

        public List<Webcast> WebcastsList { get; private set; }
    }
}