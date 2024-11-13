using Core1;
using ServerAPI1.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Repositories
{
    public class ListingRepository
    {
        private string connectionString = "mongodb://Gruppe1:<AD6RU8wHaOtQv8vH>@undefined/?replicaSet=atlas-7nlzsu-shard-0&ssl=true&authSource=admin";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Listing> collection;

        public ListingRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Gruppe1");

            collection = database.GetCollection<Listing>("Listings");
        }

        //Tilføjer en Ny Listing. 
        public async Task AddListing(Listing listing)
        {
            await collection.InsertOneAsync(listing);
        }

        //Viser alle aktive listings. 
        public async Task<List<Listing>> GetAllActiveListings()
        {
            bool active = true;
            var filter = Builders<Listing>.Filter.Eq("IsActive", active);
            return await collection.Find(filter).ToListAsync();
        }

        //Viser alle listings baseret på category.
        public async Task<List<Listing>> GetListingByCategory(string category)
        {
            var filter = Builders<Listing>.Filter.Eq("Category.Name", category);
            return await collection.Find(filter).ToListAsync();
        }

        //Viser alle listings sorteret på pris faldende.
        public async Task<List<Listing>> GetListingByPriceDescending()
        {
            var list = await collection.Aggregate()
                .SortByDescending(listing => listing.Price)
                .ToListAsync();
            return list;
        }
        //Viser alle listings sorteret på pris stigende.
        public async Task<List<Listing>> GetListingByPriceAscending()
        {
            var list = await collection.Aggregate()
                .SortByAscending(listing => listing.Price)
                .ToListAsync();
            return list;
        }

        //Viser annoncer baseret på navn som søgeord
        public async Task<List<Listing>> GetListingBySearch(string search)
        {

            return;
        }

        //Viser Aktive listings for en specifik bruger:

        public async Task<List<Listing>> GetActiveListingsByUser(ObjectId userid)
        {
            bool active = true;
            var filter1 = Builders<Listing>.Filter.Eq("User.UserId", userid);
            var filter2 = Builders<Listing>.Filter.Eq("IsActive", active);

            var combinedfilter = Builders<Listing>.Filter.And(
        filter1,
        filter2
        );
            return await collection.Find(combinedfilter).ToListAsync();
        }
    }
}
