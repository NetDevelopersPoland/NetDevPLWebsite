using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using NetDevPL.Infrastructure.Helpers;
using NetDevPLWeb.Features.Blogs;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesModule : NancyModule
    {
        readonly ResourcesSource _source = new ResourcesSource();

        public ResourcesModule()
        {
            Get["/resources"] = parameters =>
            {
                var toolsMastering = _source.GetResources();

                return View["resourcesList", new ResourcesViewModel(toolsMastering)];
            };
        }
    }

    public class ResourcesSource
    {
        public List<Resource> GetResources() =>JsonReaderHelper.ReadObjectListFromJson<Resource>("Features/Resources/resources.json");
    }

    public class Resource
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class ResourcesViewModel
    {
        public ResourcesViewModel(List<Resource> resources)
        {
            ResourcesList = resources;
        }

        public List<Resource> ResourcesList { get; private set; }
    }
}