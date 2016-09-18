using Nancy;

namespace NetDevPLWeb.Features.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["index"];
        }
    }
}