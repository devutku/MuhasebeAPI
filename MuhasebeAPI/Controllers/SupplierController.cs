using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.SupplierCommands;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SupplierController> _logger;
        public SupplierController(IMediator mediator, ILogger<SupplierController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSupplierCommand command)
        {
            try
            {
                _logger.LogInformation("CreateSupplier request received");
                var id = await _mediator.Send(command);
                _logger.LogInformation($"Supplier created with Id: {id}");
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateSupplier");
                return StatusCode(500, "Error creating supplier");
            }
        }
        // Diğer CRUD endpointleri buraya eklenebilir
    }
} 