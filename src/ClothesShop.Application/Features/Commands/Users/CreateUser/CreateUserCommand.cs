using Clothes.Application.Common.Mappings;
using Clothes.Application.Features.Common.Users;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.CreateUser;

public class CreateUserCommand : CreateOrUpdateUserCommand, IRequest<ApiResult<Guid>>, IMapFrom<CreateUserCommand>
{
    
}