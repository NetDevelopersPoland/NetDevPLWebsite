using System.Collections.Generic;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsSource
    {
        private readonly IJsonReader _jsonReader;

        public WebcastsSource(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public ICollection<Webcast> GetWebcast()
        {
            return _jsonReader.ReadAll<Webcast>("Features/Webcasts/webcastsList.json");
        }
    }
}