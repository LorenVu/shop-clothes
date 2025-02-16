using MinimalApi.Application.Common.Map;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Features.Common;

public abstract class CreateOrUpdateUserCommand : IMapFrom<User>
{
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
}