// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="FacebookDataProvider.cs" project="NetDevPL.Features.Facebook" date="2016-06-03 17:39">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using NetDevPL.Infrastructure.SharedKernel;
using Newtonsoft.Json;

namespace NetDevPL.Features.Facebook.DataProvider
{
    public class FacebookDataProvider
    {
        public List<FacebookPost> FetchDataFromFacebook()
        {
            string urlPattern = "https://graph.facebook.com/{0}/feed?fields=likes.limit(0).summary(true),type,caption,full_picture,icon,is_published,message,picture,updated_time,link,name,created_time,description,object_id,from,to&limit=50&access_token={1}";

            string pageId = "154009054780458";
            string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];
            string url = string.Format(urlPattern, pageId, accessToken);
            FacebookNewsContainer data = new FacebookNewsContainer();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream inputStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(inputStream);
                    string html = reader.ReadToEnd();
                    reader.Dispose();
                    data = JsonConvert.DeserializeObject<FacebookNewsContainer>(html);
                }

                response.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);

                return new List<FacebookPost>();
            }

            return new List<FacebookPost>(
                data.Data.Where(d => d.Likes.Summary.TotalCount > 10).Select(d => new FacebookPost
                {
                    ExternalKey = d.ObjectId,
                    CreateDate = d.CreatedDate,
                    Content = d.Message + "\n\n" + d.Name + "\n\n" + d.Link,
                    Likes = d.Likes.Summary.TotalCount
                }));
        }
    }
}