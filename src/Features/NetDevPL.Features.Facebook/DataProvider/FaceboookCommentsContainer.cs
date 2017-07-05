using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FaceboookCommentsContainer
    {
        [JsonProperty(PropertyName = "data")]
        public IList<FacebookComment> Comments { get; set; }

        [JsonProperty(PropertyName = "paging")]
        public FacebookPaging Paging { get; set; }
    }
}