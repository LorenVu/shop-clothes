using BuildingBlock.Shared.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.ActiveUser;

public record ActiveUserCommand(Guid Id) : IRequest<ApiResult<object>>;