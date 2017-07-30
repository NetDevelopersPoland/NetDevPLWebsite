using System;
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
        readonly MongoDBProvider<FacebookComment> commentsProvider = new MongoDBProvider<FacebookComment>("netdevpl", "facebookComments");

        public HLListPage<FacebookPost> PostsGetList(PostFilter filter)
        {
            var defaultFilter = Builders<FacebookPost>.Filter.Empty;
            var defaultSorting = Builders<FacebookPost>.Sort.Descending(p => p.CreateDate);

            if (filter.HasFilter)
            {
                if (filter.StartDate != null)
                {
                    defaultFilter = defaultFilter & Builders<FacebookPost>.Filter.Gte(p => p.CreateDate, filter.StartDate.Value);
                }

                if (filter.EndDate != null)
                {
                    defaultFilter = defaultFilter & Builders<FacebookPost>.Filter.Lte(p => p.CreateDate, filter.EndDate.Value);
                }

                if (!String.IsNullOrWhiteSpace(filter.Tag))
                {
                    defaultFilter = defaultFilter & Builders<FacebookPost>.Filter.AnyEq(p => p.Tags, filter.Tag);
                }
            }

            if (filter.HasSorting)
            {
                if (filter.SortingDirection == SortDirection.Ascending)
                {
                    defaultSorting = Builders<FacebookPost>.Sort.Ascending(filter.SortingExpression);
                }
                else
                {
                    defaultSorting = Builders<FacebookPost>.Sort.Descending(filter.SortingExpression);
                }
            }

            var posts = postsProvider.Collection.Find(defaultFilter).Sort(defaultSorting).ToList();

            return new HLListPage<FacebookPost>(posts, posts.Count, 1, posts.Count > 1 ? posts.Count : 1);
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
            var update = Builders<FacebookPost>.Update
                .Set(fp => fp.Likes, post.Likes)
                .Set(fp => fp.LastUpdated, post.LastUpdated);
            
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

        public void CommentsAdd(FacebookComment comment)
        {
            var fBuilder = Builders<FacebookComment>.Filter;
            var filter = fBuilder.Eq(fp => fp.PostId, comment.PostId) & fBuilder.Eq(fp => fp.UserId, comment.UserId) & fBuilder.Eq(fp => fp.Message, comment.Message);
            var result = commentsProvider.Collection.Find(filter);

            if (result.Count() == 0)
            {
                commentsProvider.Collection.InsertOne(comment);
            }
        }
        public List<FacebookComment> CommentsGetList()
        {
            return commentsProvider.Collection.Find(d => true).ToList();
        }
    }
}