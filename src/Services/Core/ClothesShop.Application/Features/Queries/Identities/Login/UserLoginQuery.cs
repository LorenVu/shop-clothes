using BuildingBlock.Shared.DTOs.Identity;
using BuildingBlock.Shared.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Identities.Login;

public record UserLoginQuery(string Email, string Password, string? TwoFactorCode, string? TwoFactorRecoveryCode) 
    : IRequest<ApiResult<LoginResponse>>, IRequest<LoginResponse>;