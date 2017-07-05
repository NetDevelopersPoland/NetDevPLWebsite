using System;
using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookComment
    {
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedDate { get; set; }
        public FacebookObject From { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }
    }
}