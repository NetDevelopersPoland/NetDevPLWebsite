using System;
using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.NetGroups
{
    public class Repository
    {
        readonly MongoDBProvider<NetGroupDataSnapshot> provider = new MongoDBProvider<NetGroupDataSnapshot>("netdevpl", "netGroupsSnapshot");

        public NetGroupDataSnapshot GetGroups()
        {
            return provider.Collection.Find(d => true).SortByDescending(d => d.SnapshotDate).Limit(1).FirstOrDefault() ?? NetGroupDataSnapshot.Create();
        }

        public void Add(NetGroupDataSnapshot snapshot)
        {
            provider.Collection.InsertOne(snapshot);
        }
    }
}