using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Customers.Queries
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
