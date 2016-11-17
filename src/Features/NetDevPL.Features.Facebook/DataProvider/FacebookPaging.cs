using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookPaging
    {
        public FacebookPagingCursors FacebookPagingCursors { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
    }
}