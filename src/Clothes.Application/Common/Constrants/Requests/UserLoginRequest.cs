namespace Clothes.Application.Common.Constrants.Requests;

public class UserLoginRequest
{
    public required string Email { get; init; }

    public required string Password { get; init; }

    public string? TwoFactorCode { get; init; }
    public string? TwoFactorRecoveryCode { get; init; }
}