using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Facebook.Domain
{
    public class FacebookSummary
    {
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
    }
}