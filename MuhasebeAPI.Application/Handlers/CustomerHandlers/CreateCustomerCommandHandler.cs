using MediatR;
using MuhasebeAPI.Application.Commands.CustomerCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerService _customerService;
        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber,
                Email = request.Email,
                Phone = request.Phone
            };
            await _customerService.AddAsync(customer);
            return customer.Id;
        }
    }
} 