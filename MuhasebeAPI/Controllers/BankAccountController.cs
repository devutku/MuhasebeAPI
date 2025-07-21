using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.BankAccountCommands;
using MuhasebeAPI.Domain.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BankAccountController> _logger;
        public BankAccountController(IMediator mediator, ILogger<BankAccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBankAccountCommand command)
        {
            try
            {
                _logger.LogInformation("CreateBankAccount request received");
                var id = await _mediator.Send(command);
                _logger.LogInformation($"BankAccount created with Id: {id}");
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateBankAccount");
                return StatusCode(500, "Error creating bank account");
            }
        }
    }
} 