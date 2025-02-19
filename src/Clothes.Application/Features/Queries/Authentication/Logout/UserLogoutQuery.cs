using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Authentication.Logout;

public record UserLogoutQuery(Guid UserId) : IRequest<ApiResult<bool>>;