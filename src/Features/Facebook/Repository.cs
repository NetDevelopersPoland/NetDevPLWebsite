// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="Repository.cs" project="NetDevPLWeb.Features.Facebook" date="2016-06-03 17:24">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPLWeb.Features.Facebook
{
    public class Repository
    {
        MongoDBProvider<FacebookPost> provider = new MongoDBProvider<FacebookPost>("netdevpl", "facebookPosts");

        public List<FacebookPost> GetList()
        {
            return new List<FacebookPost>();
        }

        public void AddOrUpdate(FacebookPost post)
        {
            var filter = Builders<FacebookPost>.Filter.Eq(fp => fp.ExternalKey, post.ExternalKey);
            var update = Builders<FacebookPost>.Update.Set(fp => fp.Likes, post.Likes);

            var updResult = provider.Collection.UpdateOne(filter, update);

            if (updResult.MatchedCount == 0)
            {
                provider.Collection.InsertOne(post);
            }

        }
    }
}