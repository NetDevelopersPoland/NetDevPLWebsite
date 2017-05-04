using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.WebCasts
{
    public class Webcast
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class WebcastsViewModel : BaseViewModel
    {
        public WebcastsViewModel(ICollection<Webcast> webcasts, Url url) : base(url)
        {
            Webcasts = webcasts;
        }

        public ICollection<Webcast> Webcasts { get; }
    }
}