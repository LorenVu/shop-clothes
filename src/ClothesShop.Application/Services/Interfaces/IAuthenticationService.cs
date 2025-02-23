using Clothes.Application.Common.Constrants.Responses;
using Clothes.Infrastructure.Shared.Responses;

namespace Clothes.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<ApiResult<LoginResponse>> LoginAsync(string email, string password);
}