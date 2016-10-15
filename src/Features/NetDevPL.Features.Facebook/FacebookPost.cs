// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="FacebookPost.cs" project="NetDevPLWeb.Features.Facebook" date="2016-06-03 17:27">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;

namespace NetDevPL.Features.Facebook
{
    public class FacebookPost
    {
        public string ExternalKey { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}