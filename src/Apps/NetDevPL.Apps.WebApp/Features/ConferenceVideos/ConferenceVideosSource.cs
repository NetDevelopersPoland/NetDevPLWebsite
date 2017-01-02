using System.Collections.Generic;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideosSource
    {
        public List<ConferenceVideo> GetConferenceVideosList() => JsonReaderHelper.ReadObjectListFromJson<ConferenceVideo>("Features/ConferenceVideos/conferenceVideosList.json");
    }
}