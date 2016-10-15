using Gmtl.HandyLib;
using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.Facebook
{
    public class Repository
    {
        readonly MongoDBProvider<FacebookPost> provider = new MongoDBProvider<FacebookPost>("netdevpl", "facebookPosts");

        public HLListPage<FacebookPost> GetList()
        {
            var posts = provider.Collection.Find(d => true).Sort(Builders<FacebookPost>.Sort.Descending(p => p.CreateDate)).ToList();

            return new HLListPage<FacebookPost>(posts, posts.Count, 1, posts.Count);
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