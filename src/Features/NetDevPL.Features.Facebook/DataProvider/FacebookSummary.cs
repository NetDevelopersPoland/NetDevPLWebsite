using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookSummary
    {
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
    }
}