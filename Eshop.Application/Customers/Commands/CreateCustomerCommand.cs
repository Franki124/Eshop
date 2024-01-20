using Eshop.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Application.Customers.Commands
{
    public class CreateCustomerCommand : CommandBase<Guid>
    {
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerEmail { get; set; }

        public CreateCustomerCommand(string customerName, string customerEmail)
        {
            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerEmail))
            {
                throw new ArgumentException("CustomerName and CustomerEmail are required.");
            }

            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }
    }
}
