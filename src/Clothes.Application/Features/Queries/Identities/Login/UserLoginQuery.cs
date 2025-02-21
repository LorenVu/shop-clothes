using Clothes.Application.Common.Constrants.Responses;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Identities.Login;

public record UserLoginQuery(string Email, string Password, string? TwoFactorCode, string? TwoFactorRecoveryCode) 
    : IRequest<ApiResult<LoginResponse>>, IRequest<LoginResponse>;