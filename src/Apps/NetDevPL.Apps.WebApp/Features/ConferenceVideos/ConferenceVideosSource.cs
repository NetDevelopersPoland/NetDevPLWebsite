using System.Collections.Generic;
using NetDevPL.Infrastructure.Services;

namespace NetDevPLWeb.Features.ConferenceVideos
{
    public class ConferenceVideosSource
    {
        private readonly IJsonReader _repository;

        public ConferenceVideosSource(IJsonReader repository)
        {
            _repository = repository;
        }

        public ICollection<ConferenceVideo> GetVideos() => _repository.ReadAll<ConferenceVideo>("Features/ConferenceVideos/conferenceVideosList.json");
    }
}