using BuildingBlock.Shared.Configs;
using BuildingBlock.Shared.Contracts.Identity;
using BuildingBlock.Shared.DTOs.Identity;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Constrants.Requests;
using Clothes.Application.Identity;
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
                .WithMessage(CodeResponseMessage.DataNotFound);

        if (!CheckPassword(requestPassword, existUser.Password, existUser.Salt))
            return ApiFailedResult<LoginResponse>
                .Instance
                .WithMessage(CodeResponseMessage.LoginFailedPasswordNotCorrect);
        
        var role = "User";
        var (accessToken, refreshToken) = jwtFactory.GetToken(new TokenRequest(existUser.Id, existUser.UserName, role));

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