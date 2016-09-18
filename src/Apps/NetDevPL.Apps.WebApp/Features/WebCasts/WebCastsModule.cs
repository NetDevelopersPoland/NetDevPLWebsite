using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsModule : NancyModule
    {
        private readonly WebcastsSource source = new WebcastsSource();

        public WebcastsModule()
        {
            Get["/webcasts"] = parameters =>
            {
                var toolsMastering = source.GetMasteringTools();

                return View["webcastsList", new WebcastsViewModel(toolsMastering)];
            };
        }
    }

    public class WebcastsSource
    {
        public List<Webcast> GetMasteringTools()
        {
            var json = File.ReadAllText("Features/Webcasts/webcastsList.json");
            var webcasts = JsonConvert.DeserializeObject<List<Webcast>>(json);
            
            return webcasts.ToList();
        }
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