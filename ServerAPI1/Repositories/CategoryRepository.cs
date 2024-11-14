using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using Core1;
using ServerAPI1.Controllers;
using System.Threading.Tasks;

namespace ServerAPI1.Repositories
{
    public class CategoryRepository
    {
        // MongoDB forbindelse
        private string connectionString = "mongodb://Gruppe1:<AD6RU8wHaOtQv8vH>@undefined/?replicaSet=atlas-7nlzsu-shard-0&ssl=true&authSource=admin";
        IMongoClient mongoClient;
        IMongoDatabase database;
        IMongoCollection<Category> collection;

        // Konstruktor for at oprette forbindelse til MongoDB
        public CategoryRepository()
        {
            mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase("Gruppe1");
            collection = database.GetCollection<Category>("Category");
        }

        // Tilføjer en ny kategori
        public async Task AddCategory(Category category)
        {
            await collection.InsertOneAsync(category);
        }
        // Henter alle kategorier
        public async Task<List<Category>> GetAllCategories()
        {
            return await collection.Find(FilterDefinition<Category>.Empty).ToListAsync();
        }

        // Henter kategori baseret på id
        public async Task<Category> GetCategoryById(ObjectId categoryId)
        {
            var filter = Builders<Category>.Filter.Eq("Category.CategoryId", categoryId);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        // Henter kategori baseret på navn
        public async Task<Category> GetCategoryByName(string name)
        {
            var filter = Builders<Category>.Filter.Eq("Name", name);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        // Opdaterer en kategori
        public async Task UpdateCategory(Category category)
        {
            var filter = Builders<Category>.Filter.Eq("Category", category);
            await collection.ReplaceOneAsync(filter, category);
        }

        // Sletter en kategori
        public async Task DeleteCategory(ObjectId categoryId)
        {
            var filter = Builders<Category>.Filter.Eq("Category.CategoryId", categoryId);
            await collection.DeleteOneAsync(filter);
        }
    }
}
