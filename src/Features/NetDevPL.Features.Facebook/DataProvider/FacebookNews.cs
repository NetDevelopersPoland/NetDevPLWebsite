using System;
using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookNews
    {
        private string message;

        public FacebookNews()
        {
            Message = string.Empty;
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    value = value.Replace("\r\n", " ").Replace("  ", " ");
                }

                message = value;
            }
        }

        [JsonProperty(PropertyName = "full_picture")]
        public string Picture { get; set; }

        [JsonProperty(PropertyName = "picture")]
        public string SmallPicture { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string PictureLink
        {
            get { return string.Format("https://graph.facebook.com/{0}/picture?type=normal", ObjectId); }
        }

        [JsonProperty(PropertyName = "id")]
        public string ObjectId { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedDate { get; set; }

        public FacebookObject From { get; set; }

        public FacebookObject To { get; set; }
        public FacebookReactions Reactions { get; set; }
    }
}