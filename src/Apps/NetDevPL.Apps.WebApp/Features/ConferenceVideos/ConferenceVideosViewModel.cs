using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideo
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class ConferenceVideosViewModel: BaseViewModel
    {
        public ConferenceVideosViewModel(List<ConferenceVideo> conferenceVideos, Url url) : base(url)
        {
            ConferenceVideosList = conferenceVideos;
        }

        public List<ConferenceVideo> ConferenceVideosList { get; private set; }
    }
}