using System.Text.Json.Serialization;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Common.Mappings;
using Clothes.Application.Features.Common.Users;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.UpdateUser;

public class UpdateUserCommand : CreateOrUpdateUserCommand, IRequest<ApiResult<UserDto>>, IMapFrom<User>
{
    [JsonIgnore]
    public Guid Id { get; private set; }
    
    public void SetId(Guid id)
    {
        Id = id;
    }
}