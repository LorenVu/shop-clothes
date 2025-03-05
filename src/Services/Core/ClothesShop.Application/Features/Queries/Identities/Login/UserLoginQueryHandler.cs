using BuildingBlock.Shared.Contracts.Identity;
using BuildingBlock.Shared.DTOs.Identity;
using BuildingBlock.Shared.Seeds;
using MediatR;

namespace Clothes.Application.Features.Queries.Identities.Login;

public class UserLoginQueryHandler(IAuthenticationService authenticationService) : IRequestHandler<UserLoginQuery, ApiResult<LoginResponse>>
{
    public Task<ApiResult<LoginResponse>> Handle(UserLoginQuery request, CancellationToken cancellationToken) =>
        authenticationService.LoginAsync(request.Email, request.Password);
}