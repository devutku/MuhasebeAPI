using MediatR;
using MuhasebeAPI.Application.Commands.SupplierCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Handlers.SupplierHandlers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly ISupplierService _supplierService;
        public CreateSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber,
                Email = request.Email,
                Phone = request.Phone
            };
            await _supplierService.AddAsync(supplier);
            return supplier.Id;
        }
    }
} 