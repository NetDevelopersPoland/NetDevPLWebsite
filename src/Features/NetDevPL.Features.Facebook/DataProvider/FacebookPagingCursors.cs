using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookPagingCursors
    {
        [JsonProperty(PropertyName = "before")]
        public string Before { get; set; }

        [JsonProperty(PropertyName = "after")]
        public string After { get; set; }
    }
}