using BuildingBlock.Shared.DTOs.Identity;
using BuildingBlock.Shared.Seeds;

namespace BuildingBlock.Shared.Contracts.Identity;

public interface IAuthenticationService
{
    Task<ApiResult<LoginResponse>> LoginAsync(string email, string password);
}