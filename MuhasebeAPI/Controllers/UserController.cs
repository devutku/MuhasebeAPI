using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.UserCommands;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        try
        {
            Console.WriteLine($"Registration attempt for phone: {command.AreaCode}-{command.PhoneNumber}");
            var result = await _mediator.Send(command);
            if (result == "Phone already registered") 
            {
                Console.WriteLine($"Registration failed: Phone {command.AreaCode}-{command.PhoneNumber} already registered");
                return BadRequest("Phone already registered.");
            }
            Console.WriteLine($"Registration successful for phone: {command.AreaCode}-{command.PhoneNumber}");
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Registration error: {ex.Message}");
            return StatusCode(500, "Internal server error during registration");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        try
        {
            Console.WriteLine($"Login attempt for phone: {command.AreaCode}-{command.PhoneNumber}");
            var token = await _mediator.Send(command);
            if (token == null) 
            {
                Console.WriteLine($"Login failed for phone: {command.AreaCode}-{command.PhoneNumber}");
                return Unauthorized("Invalid credentials.");
            }
            Console.WriteLine($"Login successful for phone: {command.AreaCode}-{command.PhoneNumber}");
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login error: {ex.Message}");
            return StatusCode(500, "Internal server error during login");
        }
    }
}
