namespace Clothes.Application.Common.Dtos;

public class UserDto
{
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public string? FullName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? PictureUrl { get; init; }
    public string? EmailAddress { get; init; }
    public int IsActive { get; init; }
    public bool IsDeleted { get; init; }
    public List<string>? Roles { get; set; }
}