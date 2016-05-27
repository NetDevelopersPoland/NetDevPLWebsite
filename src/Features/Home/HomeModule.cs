
using Nancy;

namespace NetDevPLWeb
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["index"];// "Hello .NET Developers Poland!";
        }
    }
}
