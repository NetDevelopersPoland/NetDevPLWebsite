using Nancy;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsModule : NancyModule
    {
        private readonly WebcastsSource _source = new WebcastsSource();

        public WebcastsModule()
        {
            Get["/webcasts"] = parameters =>
            {
                var webcasts = _source.GetWebcastList();

                return View["webcastsList", new WebcastsViewModel(webcasts, Request.Url)];
            };
        }
    }
}