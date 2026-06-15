using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab10_Marquez.Application.DTOs.User;
using Lab10_Marquez.Application.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Lab10_Marquez.Infrastructure.Adapters.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginRequest)
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(loginRequest.Username);
        
        if (user == null) return null;

        if (user.PasswordHash != loginRequest.Password) return null;

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var jwtSettings = _configuration.GetSection("Jwt");
        var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey no configurada.");
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var tokenExpiration = DateTime.UtcNow.AddHours(3); // Tiempo de expiración explicito

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            expires: tokenExpiration,
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = tokenExpiration
        };
    }
}