using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.Blogs
{
    public class Repository
    {
        readonly MongoDBProvider<BlogDataSnapshot> provider = new MongoDBProvider<BlogDataSnapshot>("netdevpl", "blogsSnapshot");

        public BlogDataSnapshot GetBlogs()
        {
            return provider.Collection.Find(d => true).SortByDescending(d => d.SnapshotDate).Limit(1).FirstOrDefault() ?? BlogDataSnapshot.Create();
        }

        public void Add(BlogDataSnapshot snapshot)
        {
            provider.Collection.InsertOne(snapshot);
        }
    }
}