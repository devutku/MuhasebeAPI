using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using System.Threading.Tasks;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        var result = await _userService.RegisterAsync(dto);
        if (result == null) return BadRequest("Email already registered.");
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest dto)
    {
        var token = await _userService.LoginAsync(dto);
        if (token == null) return Unauthorized("Invalid credentials.");
        return Ok(new { Token = token });
    }
}
