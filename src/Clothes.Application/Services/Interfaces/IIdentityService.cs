namespace Clothes.Application.Services.Interfaces;

public interface IIdentityService
{
    bool VerifyPassword(string password, string salt, string hash);
    string HashPassword(string password, string salt);
    string GenerateSalt();
}