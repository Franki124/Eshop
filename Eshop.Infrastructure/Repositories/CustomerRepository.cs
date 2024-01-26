using Eshop.Domain.Customers;
using Eshop.Domain.Shared;
using Eshop.Infrastructure.Database;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Eshop.Infrastructure.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly CustomersContext _context;
        private readonly IEntityTracker _entityTracker;

        public CustomerRepository(CustomersContext context, IEntityTracker entityTracker)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            return await _context.Customers.Find(filter).FirstOrDefaultAsync();
        }

        public void Add(Customer customer)
        {
            _entityTracker.TrackEntity(customer);
        }
    }
}
