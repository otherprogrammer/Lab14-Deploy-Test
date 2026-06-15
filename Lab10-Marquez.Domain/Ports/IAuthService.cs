

using Lab10_Marquez.Application.DTOs.User;

namespace Lab10_Marquez.Application.Ports;

public interface IAuthService
{
    Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginRequest);
}