using Clothes.Application.Common.Mappings;
using Clothes.Application.Features.Common.Users;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.UpdateUser;

public class UpdateUserCommand : CreateOrUpdateUserCommand, IRequest<ApiResult<User>>, IMapFrom<User>
{
    public required Guid Id { get; init; }
}