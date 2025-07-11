using MediatR;
using MuhasebeAPI.Application.Commands.BankAccountCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Handlers.BankAccountHandlers
{
    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Guid>
    {
        private readonly IBankAccountService _bankAccountService;
        public CreateBankAccountCommandHandler(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }
        public async Task<Guid> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = new BankAccount
            {
                BankName = request.BankName,
                IBAN = request.IBAN,
                AccountNumber = request.AccountNumber,
                Branch = request.Branch
            };
            await _bankAccountService.AddAsync(bankAccount);
            return bankAccount.Id;
        }
    }
} 