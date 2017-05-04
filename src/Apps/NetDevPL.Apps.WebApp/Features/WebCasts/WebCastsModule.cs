using Nancy;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsModule : NancyModule
    {
        public WebcastsModule(IJsonReader repository)
        {
            var source = new WebcastsSource(repository);

            Get["/webcasts"] = parameters =>
            {
                var webcasts = source.GetWebcast();
                return View["webcastsList", new WebcastsViewModel(webcasts, Request.Url)];
            };
        }
    }
}