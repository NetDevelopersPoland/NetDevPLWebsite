using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Conferences
{
    public class ConferencesModule : NancyModule
    {
        ConferencesSource source = new ConferencesSource();

        public ConferencesModule()
        {
            Get["/conferences"] = parameters =>
            {
                var conferences = source.GetConferences();
                return View["conferencesList", new ConferencesListViewModel(conferences)];
            };
        }
    }

    public class ConferencesSource
    {
        public List<Conference> GetConferences()
        {
            string json = File.ReadAllText("Features/Conferences/conferences.json");
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