using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;

namespace Clothes.Application.Features.Common.Users;

public abstract class CreateOrUpdateUserCommand : IMapFrom<User>
{
    public string? UserName { get; set; }
    public string? FullName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? EmailAddress { get; init; }
    public required string Password { get; init; }
}