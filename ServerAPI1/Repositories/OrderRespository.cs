using Core1;
using ServerAPI1.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Repositories
{

    public class OrderRepository
    {
        private readonly string connectionString =
            "mongodb://Gruppe1:<AD6RU8wHaOtQv8vH>@undefined/?replicaSet=atlas-7nlzsu-shard-0&ssl=true&authSource=admin";

        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Order> collection;

        // Konstruktør der initialiserer forbindelse til MongoDB
        public OrderRepository()
        {
            mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase("Gruppe1");
            collection = database.GetCollection<Order>("Order");
        }

        // Henter købshistorikken for en specifik bruger
        public async Task<List<Order>> GetPurchaseHistory(ObjectId userId)
        {
            var filter = Builders<Order>.Filter.Eq("UserId", userId);
            return await collection.Find(filter).SortByDescending(order => order.OrderDate).ToListAsync();
        }

        // Tæller det samlede antal køb for en specifik bruger
        public async Task<int> GetTotalPurchasesCount(ObjectId userId)
        {
            var filter = Builders<Order>.Filter.Eq("UserId", userId);
            return (int)await collection.CountDocumentsAsync(filter);
        }

        // Sletter en ordre baseret på OrderId
        public async Task DeleteOrder(ObjectId orderId)
        {
            var filter = Builders<Order>.Filter.Eq("OrderId", orderId); // Filtrerer baseret på OrderId
            var result = await collection.DeleteOneAsync(filter); // Sletter en ordre

            if (result.DeletedCount == 0)
            {
                throw
                    new KeyNotFoundException("Order not found."); // Hvis ingen ordren blev slettet, kast en undtagelse
            }
        }
    }
}
