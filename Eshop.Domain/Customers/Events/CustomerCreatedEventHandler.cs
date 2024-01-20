using Eshop.Domain.Customers.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Domain.Customers.EventHandlers
{
    internal class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}