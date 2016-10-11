using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetDevPLWeb.Features.OfflineEvents
{
    public class OfflineEventsModule : NancyModule
    {
        private readonly ConferencesSource _source = new ConferencesSource();

        public OfflineEventsModule()
        {
            Get["/offlineEvents"] = parameters =>
            {
                var conferences = _source.GetConferences();
                return View["offlineEventsList", new ConferencesListViewModel(conferences)];
            };
        }
    }

    public class ConferencesSource
    {
        public List<Conference> GetConferences()
        {
            var tomorrow = DateTime.Today.AddDays(1);
            string json = File.ReadAllText("Features/OfflineEvents/conferences.json");
            var conferences = JsonConvert.DeserializeObject<List<Conference>>(json, new IsoDateTimeConverter { DateTimeFormat = "d.M.yyyy" });

            return conferences.Where(c => c.EndDate > tomorrow).OrderBy(c => c.StartDate).ToList();
        }
    }

    public class Conference
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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