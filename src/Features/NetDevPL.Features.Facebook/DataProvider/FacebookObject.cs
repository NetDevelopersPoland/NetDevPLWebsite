using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}