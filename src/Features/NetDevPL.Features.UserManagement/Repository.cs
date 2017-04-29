using System;
using MongoDB.Driver;
using NetDevPL.Infrastructure.MongoDB;

namespace NetDevPL.Features.UserManagement
{
    public class Repository
    {
        readonly MongoDBProvider<User> provider = new MongoDBProvider<User>("netdevpl", "users");

        public void Add(User user)
        {
            var filter = Builders<User>.Filter.Eq(fp => fp.Email, user.Email);
            var userExists = provider.Collection.Count(filter);

            if (userExists == 0)
            {
                provider.Collection.InsertOne(user);
            }
        }
        public User GetByMail(string email)
        {
            var filter = Builders<User>.Filter.Eq(fp => fp.Email, email);

            return provider.Collection.Find(filter).Limit(1).FirstOrDefault();
        }
        public User GetById(Guid id)
        {
            var filter = Builders<User>.Filter.Eq(fp => fp.Id, id);

            return provider.Collection.Find(filter).Limit(1).FirstOrDefault();
        }
    }
}