using BuildingBlock.Shared.DTOs.Identity;
using Clothes.Application.Common.Constrants.Requests;

namespace Clothes.Application.Identity;

public interface IJwtFactory
{
    TokenResponse GetToken(TokenRequest request);
}