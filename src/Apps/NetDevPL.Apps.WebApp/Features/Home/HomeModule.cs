using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["index", new BaseViewModel()];
        }
    }
}