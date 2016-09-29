using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Groups
{
    public class GroupsModule : NancyModule
    {
        private readonly GroupsSource _source = new GroupsSource();

        public GroupsModule()
        {
            Get["/groups"] = parameters =>
            {
                var toolsMastering = _source.GetMasteringTools();

                return View["groupsList", new GroupsViewModel(toolsMastering)];
            };
        }
    }

    public class GroupsSource
    {
        public List<Group> GetMasteringTools()
        {
            var json = File.ReadAllText("Features/Groups/groupsList.json");
            var groups = JsonConvert.DeserializeObject<List<Group>>(json);
            
            return groups.ToList();
        }
    }

    public class Group
    {
        public string Url { get; set; }
        public string Title { get; set; }
    }

    public class GroupsViewModel
    {
        public GroupsViewModel(List<Group> groups)
        {
            GroupsList = groups;
        }

        public List<Group> GroupsList { get; private set; }
    }
}