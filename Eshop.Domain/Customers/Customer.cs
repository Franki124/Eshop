using Eshop.Domain.SeedWork;
using System;

namespace Eshop.Domain.Shared
{
    public class Customer : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public static Customer Create(string name, string email)
        {
            Guid newId = Guid.NewGuid();
            return new Customer(newId, name, email);
        }

        private Customer(Guid id, string name, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
