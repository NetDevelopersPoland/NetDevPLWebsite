using Nancy;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideosModule : NancyModule
    {
        private readonly ConferenceVideosSource _source = new ConferenceVideosSource();

        public ConferenceVideosModule()
        {
            Get["/conferenceVideos"] = parameters =>
            {
                var conferenceVideos = _source.GetConferenceVideosList();

                return View["conferenceVideosList", new ConferenceVideosViewModel(conferenceVideos)];
            };
        }
    }
}