namespace BuildingBlock.Shared.Contracts.ValueObjects;

public record JwtToken(string AccessToken, string RefreshToken);