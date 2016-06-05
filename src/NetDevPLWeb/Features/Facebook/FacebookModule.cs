using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Nancy;
using NetDevPLWeb.Features.Facebook.DataProvider;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookModule : NancyModule
    {
        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
             return "OK";
                //return View["facebookPosts", new FacebookPostsViewModel()];
               
            };
        }
    }
}