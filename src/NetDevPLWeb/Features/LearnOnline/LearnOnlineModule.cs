using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class LearnOnlineModule : NancyModule
    {
        LearnOnlineSource source = new LearnOnlineSource();

        public LearnOnlineModule()
        {
            Get["/learnOnline"] = parameters =>
            {
                var blogs = source.GetBlogs();
                return View["learnOnlineList", new LearOnlineListViewModel(blogs)];
            };
        }
    }

    public class LearnOnlineSource
    {
        public List<ToolMastering> GetBlogs()
        {
            string json = File.ReadAllText("Features/LearnOnline/toolsMastering.json");
            var toolMasterings = JsonConvert.DeserializeObject<List<ToolMastering>>(json);

            //Randomize order to not favorize any
            return toolMasterings.ToList();
        }
    }

    public class ToolMastering
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class LearOnlineListViewModel
    {
        public LearOnlineListViewModel(List<ToolMastering> toolMastering)
        {
            ToolMastering = toolMastering;
        }

        public List<ToolMastering> ToolMastering { get; set; }
    }
}