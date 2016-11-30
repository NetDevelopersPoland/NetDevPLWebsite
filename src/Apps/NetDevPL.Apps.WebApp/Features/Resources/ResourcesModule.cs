using Nancy;

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

    public class Resource
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}