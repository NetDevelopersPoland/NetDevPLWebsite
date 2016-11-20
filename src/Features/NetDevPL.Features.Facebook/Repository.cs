using System.Collections.Generic;
using Gmtl.HandyLib;
using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.Facebook
{
    public class Repository
    {
        readonly MongoDBProvider<FacebookPost> postsProvider = new MongoDBProvider<FacebookPost>("netdevpl", "facebookPosts");
        readonly MongoDBProvider<FacebookUser> usersProvider = new MongoDBProvider<FacebookUser>("netdevpl", "facebookUsers");
        readonly MongoDBProvider<FacebookLike> likesProvider = new MongoDBProvider<FacebookLike>("netdevpl", "facebookLikes");

        public HLListPage<FacebookPost> PostsGetList()
        {
            var posts = postsProvider.Collection.Find(d => true).Sort(Builders<FacebookPost>.Sort.Descending(p => p.CreateDate)).ToList();

            return new HLListPage<FacebookPost>(posts, posts.Count, 1, posts.Count);
        }

        public List<FacebookUser> UsersGetList()
        {
            return usersProvider.Collection.Find(d => true).ToList();
        }

        public List<FacebookLike> LikesGetList()
        {
            return likesProvider.Collection.Find(d => true).ToList();
        }

        public void PostsAddOrUpdate(FacebookPost post)
        {
            var filter = Builders<FacebookPost>.Filter.Eq(fp => fp.ExternalKey, post.ExternalKey);
            var update = Builders<FacebookPost>.Update.Set(fp => fp.Likes, post.Likes);

            var updResult = postsProvider.Collection.UpdateOne(filter, update);

            if (updResult.MatchedCount == 0)
            {
                postsProvider.Collection.InsertOne(post);
            }
        }

        public void UsersAddOrUpdate(FacebookUser user)
        {
            var filter = Builders<FacebookUser>.Filter.Eq(fp => fp.Id, user.Id);
            var update = Builders<FacebookUser>.Update.Set(fp => fp.Name, user.Name);

            var updResult = usersProvider.Collection.UpdateOne(filter, update);

            if (updResult.MatchedCount == 0)
            {
                usersProvider.Collection.InsertOne(user);
            }
        }

        public void LikesAdd(FacebookLike like)
        {
            var fBuilder = Builders<FacebookLike>.Filter;
            var filter = fBuilder.Eq(fp => fp.PostId, like.PostId) & fBuilder.Eq(fp => fp.UserId, like.UserId);
            var result = likesProvider.Collection.Find(filter);

            if (result.Count() == 0)
            {
                likesProvider.Collection.InsertOne(like);
            }
        }
    }
}