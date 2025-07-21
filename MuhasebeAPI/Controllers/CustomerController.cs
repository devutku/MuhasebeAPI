using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.CustomerCommands;
using MuhasebeAPI.Domain.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerCommand command)
        {
            try
            {
                _logger.LogInformation("CreateCustomer request received");
                var id = await _mediator.Send(command);
                _logger.LogInformation($"Customer created with Id: {id}");
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateCustomer");
                return StatusCode(500, "Error creating customer");
            }
        }
        // Diğer CRUD endpointleri buraya eklenebilir
    }
} 