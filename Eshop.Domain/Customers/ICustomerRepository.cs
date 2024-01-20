using Eshop.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace Eshop.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);

        void Add(Customer customer);
    }
}
