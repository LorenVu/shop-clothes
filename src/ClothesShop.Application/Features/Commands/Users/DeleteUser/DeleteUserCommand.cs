using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<ApiResult<bool>>;