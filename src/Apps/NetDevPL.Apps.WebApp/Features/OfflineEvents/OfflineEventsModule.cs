using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Conferences
{
    public class OfflineEventsModule : NancyModule
    {
        readonly ConferencesSource source = new ConferencesSource();

        public OfflineEventsModule()
        {
            Get["/offlineEvents"] = parameters =>
            {
                var conferences = source.GetConferences();
                return View["offlineEventsList", new ConferencesListViewModel(conferences)];
            };
        }
    }

    public class ConferencesSource
    {
        public List<Conference> GetConferences()
        {
            string json = File.ReadAllText("Features/OfflineEvents/conferences.json");
            var conferences = JsonConvert.DeserializeObject<List<Conference>>(json);
            
            return conferences;
        }
    }

    public class Conference
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string When { get; set; }
        public string Location { get; set; }
    }

    public class ConferencesListViewModel
    {
        public ConferencesListViewModel(List<Conference> conferences)
        {
            Conferences = conferences;
        }

        public List<Conference> Conferences { get; set; }
    }
}