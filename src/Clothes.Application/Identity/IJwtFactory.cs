using Clothes.Application.Common.Constrants.Requests;
using Clothes.Application.Common.Constrants.Responses;

namespace Clothes.Application.Identity;

public interface IJwtFactory
{
    TokenResponse GetToken(TokenRequest request);
}