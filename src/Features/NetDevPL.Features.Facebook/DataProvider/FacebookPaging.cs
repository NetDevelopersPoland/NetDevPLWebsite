using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookPaging
    {
        [JsonProperty(PropertyName = "cursors")]
        public FacebookPagingCursors FacebookPagingCursors { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
    }
}