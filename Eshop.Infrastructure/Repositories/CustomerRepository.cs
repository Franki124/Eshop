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

        public CustomerRepository(CustomersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            return await _context.Customers.Find(filter).FirstOrDefaultAsync();
        }

        void ICustomerRepository.Add(Customer customer)
        {
            _context.Customers.InsertOne(customer);
        }
    }
}
