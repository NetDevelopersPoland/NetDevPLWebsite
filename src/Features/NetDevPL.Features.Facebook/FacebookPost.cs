using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetDevPL.Features.Facebook
{
    public class FacebookPost
    {
        private static Regex httpRegex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- .,/#?%&=@]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex hashtagRegex = new Regex(@"^#[A-Za-z0-9-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public string ExternalKey { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        /// <summary>
        /// All http addresses are converted into http links
        /// eg. Test http://example.com => Test <a href="http://example.com" target="_new">http://example.com</a>
        /// </summary>
        public string ContentWithHyperLinks
        {
            get
            {
                return String.IsNullOrEmpty(Content) ? String.Empty : httpRegex.Replace(Content, m => String.Format("<a href=\"{0}\" target=\"_new\">{0}</a>", m.Value));
            }
        }

        public int Likes { get; set; }

        /// <summary>
        /// FacebookUser Id
        /// </summary>
        public string CreatorId { get; set; }

        public DateTime LastUpdated { get; set; }

        public static List<string> ExtractTags(string content)
        {
            return content
                .Split()
                .Where(s => hashtagRegex.IsMatch(s))
                .Select(s => s.Substring(1).ToLowerInvariant())
                .ToList();
        }
    }
}