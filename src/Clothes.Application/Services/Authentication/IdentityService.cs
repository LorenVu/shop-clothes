using System.Security.Cryptography;
using System.Text;
using Clothes.Application.Services.Interfaces;

namespace Clothes.Application.Services.Authentication;

public class IdentityService : IIdentityService
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

    public bool VerifyPassword(string password, string salt, string passwordHash)
    {
        var hash = HashPassword(password, salt);
        return string.Equals(passwordHash, hash, StringComparison.Ordinal);
    }

    public string HashPassword(string password, string salt)
    {
        var saltBytes = Encoding.UTF8.GetBytes(salt); 
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), saltBytes, Iterations, _hashAlgorithm, KeySize);

        return Convert.ToHexString(hash);
    }

    public string GenerateSalt() => 
        Convert.ToBase64String(RandomNumberGenerator.GetBytes(KeySize));
}