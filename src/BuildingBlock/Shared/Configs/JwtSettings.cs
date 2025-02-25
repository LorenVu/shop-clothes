namespace BuildingBlock.Shared.Configs;

public sealed class JwtSettings
{
    public string? SecretKey { get; private set; }
    public string? Issuer { get; private set; }
    public string? Audience { get; private set; }
    public int AccessTokenExpiration { get; private set; }
    public int RefreshTokenExpiration { get; private set; }
}