using Clothes.Application.Common.Constrants.Requests;
using Clothes.Application.Features.Queries.Identities.Login;
using Clothes.Application.Features.Queries.Identities.Logout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.API.Controllers.Authentication;

[Route("/api/v1/[controller]")]
public class AuthenticationController(IMediator mediator) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        var query = new UserLoginQuery(request.Email, request.Password, request.TwoFactorCode, request.TwoFactorRecoveryCode);
        var result = await mediator.Send(query);

        return Ok(result);
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] UserLogoutRequest request)
    {
        var query = new UserLogoutQuery(request.UserId);
        var result = await mediator.Send(query);

        return Ok(result);
    }
}