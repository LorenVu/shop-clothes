using BuildingBlock.Shared.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Identities.Logout;

public record UserLogoutQuery(Guid UserId) : IRequest<ApiResult<bool>>;