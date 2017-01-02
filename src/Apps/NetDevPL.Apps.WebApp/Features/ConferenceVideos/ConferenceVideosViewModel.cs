using System.Collections.Generic;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideo
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class ConferenceVideosViewModel
    {
        public ConferenceVideosViewModel(List<ConferenceVideo> conferenceVideos)
        {
            ConferenceVideosList = conferenceVideos;
        }

        public List<ConferenceVideo> ConferenceVideosList { get; private set; }
    }
}