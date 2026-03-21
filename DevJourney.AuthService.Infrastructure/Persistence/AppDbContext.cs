using DevJourney.AuthService.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DevJourney.AuthService.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoCliente = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = mongoCliente.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }
        //public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
