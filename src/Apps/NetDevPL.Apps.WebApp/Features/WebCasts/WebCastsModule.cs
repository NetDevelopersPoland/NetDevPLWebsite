using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using NetDevPL.Infrastructure.Helpers;
using NetDevPLWeb.Features.Resources;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsModule : NancyModule
    {
        private readonly WebcastsSource _source = new WebcastsSource();

        public WebcastsModule()
        {
            Get["/webcasts"] = parameters =>
            {
                var toolsMastering = _source.GetWebcastList();

                return View["webcastsList", new WebcastsViewModel(toolsMastering)];
            };
        }
    }

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