using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Authentication.Logout;

public class UserLogoutQueryHandler : IRequestHandler<UserLogoutQuery, ApiResult<bool>>
{
    public Task<ApiResult<bool>> Handle(UserLogoutQuery request, CancellationToken cancellationToken)
    {
        return default;
    }
}