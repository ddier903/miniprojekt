using Core1;
using ServerAPI1.Controllers;

namespace ServerAPI1.Repositories
{
    public class UserRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Customer> collection;

        public UserRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Gruppe1");

            collection = database.GetCollection<User>("Users");
        }

        //Tilføjer User til database
        public async Task AddUser(User user)
        {
            await collection.InsertOneAsync(user);
        }

        //Henter alle users
        public async Task<List<User>> GetAllUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }
    }
}
