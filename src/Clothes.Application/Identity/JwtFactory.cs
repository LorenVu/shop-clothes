using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clothes.Application.Common.Constrants.Requests;
using Clothes.Application.Common.Constrants.Responses;
using Clothes.Domain.Configs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Clothes.Application.Identity;

public class JwtFactory(IOptions<JwtSettings> jwtSettings) : IJwtFactory
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
    public TokenResponse GetToken(TokenRequest request)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, request.Uid.ToString()),
            new(ClaimTypes.NameIdentifier, request.UserName),
            new(ClaimTypes.Role, request.Role)
        };
        
        var token = GenerateJwt(claims);
        var result =   new TokenResponse(token, GenerateRefreshToken());
        return result;
    }
    
    public string GenerateRefreshToken() =>
        Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    
    private string GenerateJwt(List<Claim> claims) => GenerateEncryptedtoken(GetSigningCredentials(), claims);
    
    private string GenerateEncryptedtoken(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiration),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] secret = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
        var length = secret.Length;
        return new SigningCredentials(new SymmetricSecurityKey(secret), 
            SecurityAlgorithms.HmacSha256);
    }
}