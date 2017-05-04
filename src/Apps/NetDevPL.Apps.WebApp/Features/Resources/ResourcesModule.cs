using Nancy;
using NetDevPL.Infrastructure.Services;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesModule : NancyModule
    {
        public ResourcesModule(IJsonReader repository)
        {
            var source = new ResourcesSource(repository);
            
            Get["/resources"] = parameters =>
            {
                var toolsMastering = source.GetResources();

                return View["resourcesList", new ResourcesViewModel(toolsMastering, Request.Url)];
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