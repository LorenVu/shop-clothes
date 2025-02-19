using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;

namespace Clothes.Application.Features.Common.Users;

public abstract class CreateOrUpdateUserCommand : IMapFrom<User>
{
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
}