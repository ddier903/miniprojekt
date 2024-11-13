using Core1;
using ServerAPI1.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Repositories
{
    public class UserRepository
    {
        private string connectionString = "mongodb://Gruppe1:<AD6RU8wHaOtQv8vH>@undefined/?replicaSet=atlas-7nlzsu-shard-0&ssl=true&authSource=admin";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<User> collection;

        public UserRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Gruppe1");

            collection = database.GetCollection<User>("Users");
        }

        public async Task AddUser(User user)
        {
            await collection.InsertOneAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            return await collection.Find(filter).ToList();
        }
    }
}
