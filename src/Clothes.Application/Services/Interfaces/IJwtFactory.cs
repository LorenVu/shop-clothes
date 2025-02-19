namespace Clothes.Application.Services.Interfaces;

public interface IJwtFactory
{
    string GenerateAccessToken(Guid userId, string? email, string username, string role);
    string GenerateRefreshToken();
}