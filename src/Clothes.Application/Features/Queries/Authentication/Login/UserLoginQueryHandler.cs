using Clothes.Application.Common.Constrants.Responses;
using Clothes.Application.Services.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Authentication.Login;

public class UserLoginQueryHandler(IAuthenticationService authenticationService) : IRequestHandler<UserLoginQuery, ApiResult<LoginResponse>>
{
    public Task<ApiResult<LoginResponse>> Handle(UserLoginQuery request, CancellationToken cancellationToken) =>
        authenticationService.LoginAsync(request.Email, request.Password);
}