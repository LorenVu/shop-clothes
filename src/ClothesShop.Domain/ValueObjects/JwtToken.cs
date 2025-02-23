namespace Clothes.Domain.ValueObjects;

public record JwtToken(string AccessToken, string RefreshToken);