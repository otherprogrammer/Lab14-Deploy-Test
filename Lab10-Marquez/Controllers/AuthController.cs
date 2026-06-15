using Microsoft.AspNetCore.Mvc;
using Lab10_Marquez.Application.DTOs.User;
using Lab10_Marquez.Application.Ports;

namespace Lab10_Marquez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
    {
        var result = await _authService.LoginAsync(loginRequest);

        if (result == null)
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        return Ok(result);
    }
}