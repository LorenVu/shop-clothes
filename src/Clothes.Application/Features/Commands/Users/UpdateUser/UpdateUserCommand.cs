using MediatR;
using MinimalApi.Application.Common.Map;
using MinimalApi.Application.Features.Common;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;

public class UpdateUserCommand : CreateOrUpdateUserCommand, IRequest<ApiResult<User>>, IMapFrom<User>
{
    public required Guid Id { get; init; }
}