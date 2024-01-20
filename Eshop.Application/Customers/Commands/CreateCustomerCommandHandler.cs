using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.Customers;
using Eshop.Domain.SeedWork;
using Eshop.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CustomerName) || string.IsNullOrEmpty(request.CustomerEmail))
            {
                throw new ArgumentException("CustomerName and CustomerEmail are required.");
            }

            var customer = Customer.Create(request.CustomerName, request.CustomerEmail);

            _customerRepository.Add(customer);

            await _unitOfWork.CommitAsync(cancellationToken);

            return customer.Id;
        }
    }
}
