using Gmtl.HandyLib;
using MongoDB.Driver;
using NetDevPL.Features.Facebook.DataProvider;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.Facebook
{
    public class Repository
    {
        readonly MongoDBProvider<FacebookPost> postsProvider = new MongoDBProvider<FacebookPost>("netdevpl", "facebookPosts");
        readonly MongoDBProvider<FacebookObject> usersProvider = new MongoDBProvider<FacebookObject>("netdevpl", "facebookUsers");
        readonly MongoDBProvider<FacebookLike> likesProvider = new MongoDBProvider<FacebookLike>("netdevpl", "facebookLikes");

        public HLListPage<FacebookPost> GetList()
        {
            var posts = postsProvider.Collection.Find(d => true).Sort(Builders<FacebookPost>.Sort.Descending(p => p.CreateDate)).ToList();

            return new HLListPage<FacebookPost>(posts, posts.Count, 1, posts.Count);
        }

        public void AddOrUpdate(FacebookPost post)
        {
            var filter = Builders<FacebookPost>.Filter.Eq(fp => fp.ExternalKey, post.ExternalKey);
            var update = Builders<FacebookPost>.Update.Set(fp => fp.Likes, post.Likes);

            var updResult = postsProvider.Collection.UpdateOne(filter, update);

            if (updResult.MatchedCount == 0)
            {
                postsProvider.Collection.InsertOne(post);
            }
        }
    }
}