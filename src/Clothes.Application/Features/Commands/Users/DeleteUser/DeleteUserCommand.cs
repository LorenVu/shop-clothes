using MediatR;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;

public record DeleteUserCommand(Guid Id) : IRequest<ApiResult<bool>>;