using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.Blogs
{
    public class Repository
    {
        readonly MongoDBProvider<BlogDataSnapshot> _provider = new MongoDBProvider<BlogDataSnapshot>("netdevpl", "blogsSnapshot");

        public BlogDataSnapshot GetBlogs()
        {
            return _provider.Collection.Find(d => true).SortByDescending(d => d.SnapshotDate).Limit(1).FirstOrDefault() ?? BlogDataSnapshot.Create();
        }

        public void Add(BlogDataSnapshot snapshot)
        {
            _provider.Collection.InsertOne(snapshot);
        }
    }
}