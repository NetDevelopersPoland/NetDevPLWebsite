using System.Collections.Generic;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsSource
    {
        public List<Webcast> GetWebcastList() => JsonReaderHelper.ReadObjectListFromJson<Webcast>("Features/Webcasts/webcastsList.json");
    }

    public class Webcast
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class WebcastsViewModel
    {
        public WebcastsViewModel(List<Webcast> webcasts)
        {
            WebcastsList = webcasts;
        }

        public List<Webcast> WebcastsList { get; private set; }
    }
}
