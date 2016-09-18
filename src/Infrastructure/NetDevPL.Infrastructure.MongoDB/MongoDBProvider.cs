using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace NetDevPL.Infrastructure.MongoDB
{
    public class MongoDBProvider<T>
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private readonly string databaseName;

        private readonly string collectionName;

        public MongoDBProvider(string databaseName, string collectionName)
        {
            this.databaseName = databaseName;
            this.collectionName = collectionName;

            InitDB();
        }

        static MongoDBProvider()
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }

        public IMongoCollection<T> Collection => database.GetCollection<T>(collectionName);

        private void InitDB()
        {

            client = new MongoClient();

            database = client.GetDatabase(databaseName);

            if (CollectionExists(database, collectionName)) return;

            CreateCollectionOptions options = new CreateCollectionOptions { AutoIndexId = true };
            database.CreateCollection(collectionName, options);
        }

        private bool CollectionExists(IMongoDatabase db, string collName)
        {
            var filter = new BsonDocument("name", collName);
            var collections = db.ListCollections(new ListCollectionsOptions { Filter = filter });

            return collections.Any();
        }
    }
}