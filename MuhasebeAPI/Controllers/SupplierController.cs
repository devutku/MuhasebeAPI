using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.SupplierCommands;
using MuhasebeAPI.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        // Diğer CRUD endpointleri buraya eklenebilir
    }
} 