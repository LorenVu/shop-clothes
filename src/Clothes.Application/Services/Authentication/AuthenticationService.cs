using Clothes.Application.Common.Constrants.Responses;
using Clothes.Application.Services.Interfaces;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;

namespace Clothes.Application.Services.Authentication;

public class AuthenticationService(IJwtFactory jwtFactory, IIdentityService identityService, IUserRepository userRepository) : IAuthenticationService
{
    public async Task<ApiResult<LoginResponse>> LoginAsync(string email, string requestPassword)
    {
        var existUser = await userRepository.GetUserByEmailAsync(email);
        if(existUser == null)
            return ApiFailedResult<LoginResponse>
                .Instance
                .WithMessage("Not found user");

        if (!CheckPassword(requestPassword, existUser.Password, existUser.Salt))
            return ApiFailedResult<LoginResponse>
                .Instance
                .WithMessage("Password is not match");
        
        var role = "User";
        var accessToken = jwtFactory.GenerateAccessToken(existUser.Id, existUser.EmailAddress, existUser.UserName, role);
        var refreshToken = jwtFactory.GenerateRefreshToken();

        return ApiSuccessResult<LoginResponse>.Instance
            .WithMessage()
            .WithData(new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
    }
    
    public async Task ForceLogoutAsync(Guid userId)
    {
        // Thực hiện logic thu hồi access_token (VD: Xóa khỏi Redis)
        await Task.CompletedTask;
    }

    private bool CheckPassword(string requestPassword, string userassword, string salt) =>
        identityService.VerifyPassword(requestPassword, salt, userassword);


}