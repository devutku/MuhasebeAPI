using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.BankAccountCommands;
using MuhasebeAPI.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BankAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBankAccountCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
} 