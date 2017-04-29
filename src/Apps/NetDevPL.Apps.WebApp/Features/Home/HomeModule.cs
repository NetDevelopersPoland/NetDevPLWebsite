using Nancy;
using Nancy.Authentication.Forms;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["index", new BaseViewModel(Request.Url)];

            //TODO prepare view for providers logins
            Get["/login"] = parameters => View["login", new BaseViewModel(Request.Url)];

            Get["/logout"] = parameters => this.LogoutAndRedirect("/");
        }
    }
}