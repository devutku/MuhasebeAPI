using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.UserCommands;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] CreateUserCommand command)
    {
        try
        {
            _logger.LogInformation($"Registration attempt for phone: {command.AreaCode}-{command.PhoneNumber}");
            var result = await _mediator.Send(command);
            if (result == "Phone already registered") 
            {
                _logger.LogWarning($"Registration failed: Phone {command.AreaCode}-{command.PhoneNumber} already registered");
                return BadRequest("Phone already registered.");
            }
            _logger.LogInformation($"Registration successful for phone: {command.AreaCode}-{command.PhoneNumber}");
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Registration error: {ex.Message}");
            return StatusCode(500, "Internal server error during registration");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
    {
        try
        {
            _logger.LogInformation($"Login attempt for phone: {command.AreaCode}-{command.PhoneNumber}");
            var token = await _mediator.Send(command);
            if (token == null) 
            {
                _logger.LogWarning($"Login failed for phone: {command.AreaCode}-{command.PhoneNumber}");
                return Unauthorized("Invalid credentials.");
            }
            _logger.LogInformation($"Login successful for phone: {command.AreaCode}-{command.PhoneNumber}");
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Login error: {ex.Message}");
            return StatusCode(500, "Internal server error during login");
        }
    }
}
