using Eshop.Domain.Customers;
using Eshop.Domain.Shared;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database
{
    internal class CustomersContext
    {
        private readonly IMongoDatabase _database;

        public CustomersContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>(nameof(Customers));
    }
}
