using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.Commands.BankAccountCommands
{
    public class CreateBankAccountCommand : IRequest<Guid>
    {
        [Required]
        public string BankName { get; set; } = null!;
        public string? IBAN { get; set; }
        public string? AccountNumber { get; set; }
        public string? Branch { get; set; }
    }
} 