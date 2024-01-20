using Eshop.Domain.SeedWork;
using System;

namespace Eshop.Domain.Customers.Events
{
    public class CustomerCreatedEvent : DomainEventBase
    {
        public Guid CustomerId { get; }

        public string CustomerName { get; }

        public string CustomerEmail { get; }

        public CustomerCreatedEvent(Guid customerId, string customerName, string customerEmail)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }
    }
}