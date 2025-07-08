using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using System.Threading.Tasks;
using MediatR;
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
            Console.WriteLine($"Registration attempt for email: {command.Email}");
            var result = await _mediator.Send(command);
            if (result == "Email already registered") 
            {
                Console.WriteLine($"Registration failed: Email {command.Email} already registered");
                return BadRequest("Email already registered.");
            }
            Console.WriteLine($"Registration successful for email: {command.Email}");
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
            Console.WriteLine($"Login attempt for email: {command.Email}");
            var token = await _mediator.Send(command);
            if (token == null) 
            {
                Console.WriteLine($"Login failed for email: {command.Email}");
                return Unauthorized("Invalid credentials.");
            }
            Console.WriteLine($"Login successful for email: {command.Email}");
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login error: {ex.Message}");
            return StatusCode(500, "Internal server error during login");
        }
    }
}
