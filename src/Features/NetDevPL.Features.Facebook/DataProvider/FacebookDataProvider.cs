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
        public IList<FacebookPost> FetchPostsFromFacebook()
        {
            string urlPattern = "https://graph.facebook.com/v2.9/{0}/feed?fields=reactions.limit(0).summary(true),type,caption,full_picture,icon,is_published,message,picture,updated_time,link,name,created_time,description,object_id,from,to&limit=50&access_token={1}";

            string pageId = "154009054780458";
            FacebookNewsContainer data = GetList<FacebookNewsContainer>(CreateAccessUrl(urlPattern, pageId));

            return new List<FacebookPost>(
                data.Data.Where(d => d.Reactions.Summary.TotalCount > 10).Select(d =>
                {
                    string content = d.Message + "\n\n" + d.Name + "\n\n" + d.Link;

                    return new FacebookPost
                    {
                        ExternalKey = d.ObjectId,
                        CreateDate = d.CreatedDate,
                        Content = content,
                        Likes = d.Reactions.Summary.TotalCount,
                        CreatorId = d.From.Id,
                        Tags = FacebookPost.ExtractTags(content),
                        LastUpdated = DateTime.Now
                    };
                }));
        }

        public Tuple<IList<FacebookLike>, IList<FacebookUser>> GetLikesAndUsersForPostFromFacebook(string postId)
        {
            List<FacebookLike> likes = new List<FacebookLike>();
            List<FacebookUser> users = new List<FacebookUser>();

            string urlPattern = "https://graph.facebook.com/{0}/likes?limit=5&access_token={1}";

            do
            {
                FacebookLikesContainer likesResponse = GetList<FacebookLikesContainer>(CreateAccessUrl(urlPattern, postId));

                likes.AddRange(likesResponse.Likes.Select(l => new FacebookLike { PostId = postId, UserId = l.Id }));
                users.AddRange(likesResponse.Likes.Select(l => new FacebookUser { Name = l.Name, Id = l.Id }));

                urlPattern = likesResponse.Paging.Next;
            } while (!string.IsNullOrWhiteSpace(urlPattern));

            return new Tuple<IList<FacebookLike>, IList<FacebookUser>>(likes, users);
        }

        private static string CreateAccessUrl(string urlPattern, params string[] args)
        {
            string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];

            string[] arguments = new string[args.Length + 1];

            for (int i = 0; i < args.Length; i++)
            {
                arguments[i] = args[i];
            }

            arguments[args.Length] = accessToken;

            return string.Format(urlPattern, arguments);
        }

        private T GetList<T>(string url) where T : new()
        {
            T data = new T();

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
                    data = JsonConvert.DeserializeObject<T>(html);
                }

                response.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);

                return new T();
            }

            return data;
        }
    }
}