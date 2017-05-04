using Nancy;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideosModule : NancyModule
    {
        public ConferenceVideosModule(IJsonReader repository)
        {
            var source = new ConferenceVideosSource(repository);
            Get["/conferenceVideos"] = parameters =>
            {
                var conferenceVideos = source.GetVideos();

                return View["conferenceVideosList", new ConferenceVideosViewModel(conferenceVideos, Request.Url)];
            };
        }
    }
}