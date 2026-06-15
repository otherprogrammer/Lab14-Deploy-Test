namespace Lab10_Marquez.Application.DTOs.User;

public class AuthResponseDto
{
    public string Username { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}