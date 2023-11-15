using Gatherama.Shared;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
namespace Gatherama.Server.Models
{
    public class GatheramaDbContext : DbContext
    {
        private readonly IMongoDatabase _db;

        public GatheramaDbContext(string connectionString, string dbName)
        {
            var client = new MongoClient("Replace with your MongoDb connection string"); //Replace with your MongoDb connection string
            _db = client.GetDatabase("Replace with your MongoDb collection name");
        }

        public IMongoCollection<Person> Persons => _db.GetCollection<Person>("Person");
        public IMongoCollection<Finding> Findings => _db.GetCollection<Finding>("Finding");
        public IMongoCollection<Friendship> Friendships => _db.GetCollection<Friendship>("Friendship");
        public IMongoCollection<Media> Media => _db.GetCollection<Media>("Media");
        public IMongoCollection<Place> Place => _db.GetCollection<Place>("Place");
        public IMongoCollection<Species> Species => _db.GetCollection<Species>("Species");
    }
}
