using MediatR;
using MinimalApi.Application.Common.Map;
using MinimalApi.Application.Features.Common;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;

public class CreateUserCommand : CreateOrUpdateUserCommand, IRequest<ApiResult<Guid>>, IMapFrom<CreateUserCommand>
{
    
}