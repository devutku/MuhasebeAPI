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
    public async Task<IActionResult> Register([FromForm] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (result == "Registration failed") 
            return BadRequest("Email already registered.");
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
    {
        var token = await _mediator.Send(command);
        if (token == null) 
            return Unauthorized("Invalid credentials.");
        return Ok(new { Token = token });
    }
}
