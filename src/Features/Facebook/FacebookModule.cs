using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Nancy;
using NetDevPLWeb.Features.Facebook.Domain;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Facebook
{
    public class FacebookModule : NancyModule
    {
        public FacebookModule()
        {
            Get["/facebook"] = parameters =>
            {
                string urlPattern = "https://graph.facebook.com/{0}/feed?fields=likes.limit(0).summary(true),type,caption,full_picture,icon,is_published,message,picture,updated_time,link,name,created_time,description,object_id,from,to&limit=25&access_token={1}";

                string pageId = "154009054780458";
                string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];
                string url = string.Format(urlPattern, pageId, accessToken);
                FacebookNewsContainer data = new FacebookNewsContainer();

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0";

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    try
                    {
                        using (Stream inputStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(inputStream);
                            string html = reader.ReadToEnd();
                            reader.Dispose();
                            data = JsonConvert.DeserializeObject<FacebookNewsContainer>(html);
                        }

                        response.Dispose();
                    }
                    catch (NullReferenceException ex)
                    {
                        //TODO log
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    //TODO log
                    Console.WriteLine(ex.Message);
                }

                return String.Join("<hr/>", data.Data.Select(d =>
                    String.Format("<p>{0}<br/> {1}<p><p>Id:{2} Likes:{3}</p>", d.CreatedDate, d.Message, d.ObjectId, d.Likes.Summary.TotalCount)

                //return View["facebookPosts", new FacebookPostsViewModel()];
                ));
            };
        }
    }
}