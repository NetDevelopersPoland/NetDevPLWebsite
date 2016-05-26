
using Nancy;

namespace NetDevPLWeb
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello .NET Developers Poland!";
        }
    }
}
