// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="FacebookPost.cs" project="NetDevPLWeb.Features.Facebook" date="2016-06-03 17:27">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;

namespace NetDevPL.Features.Facebook
{
    public class FacebookPost
    {
        private static Regex httpRegex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string ExternalKey { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// All http addresses are converted into http links
        /// eg. Test http://example.com => Test <a href="http://example.com" target="_new">http://example.com</a>
        /// </summary>
        public string ContentWithHyperLinks
        {
            get
            {
                return httpRegex.Replace(Content, m => String.Format("<a href=\"{0}\" target=\"_new\">{0}</a>", m.Value));
            }
        }

        public int Likes { get; set; }

        /// <summary>
        ///     FacebookUser Id
        /// </summary>
        public string CreatorId { get; set; }
    }
}