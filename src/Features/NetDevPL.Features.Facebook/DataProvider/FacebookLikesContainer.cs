using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookLikesContainer
    {
        [JsonProperty(PropertyName = "data")]
        public IList<FacebookObject> Likes { get; set; }

        [JsonProperty(PropertyName = "paging")]
        public FacebookPaging Paging { get; set; }
    }
}