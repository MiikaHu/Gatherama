using Gatherama.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gatherama.Server.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _personsCollection;

        public PersonService(
            IOptions<GatheramaDatabaseSettings> gatheramaDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gatheramaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gatheramaDatabaseSettings.Value.DatabaseName);

            _personsCollection = mongoDatabase.GetCollection<Person>(
                gatheramaDatabaseSettings.Value.PersonCollectionName);
        }

        public async Task<List<Person>> GetAsync() =>
            await _personsCollection.Find(_ => true).ToListAsync();
    }
}
