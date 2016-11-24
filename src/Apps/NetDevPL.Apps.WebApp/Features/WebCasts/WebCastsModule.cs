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
                var toolsMastering = _source.GetWebcastList();

                return View["webcastsList", new WebcastsViewModel(toolsMastering)];
            };
        }
    }
}