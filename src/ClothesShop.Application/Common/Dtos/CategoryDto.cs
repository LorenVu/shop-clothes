namespace Clothes.Application.Common.Dtos;

public class CategoryDto
{
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Code { get;init; }
    public string? Icon { get; init; }
    public int ParentId { get; init; }
    public int SortOrder { get; init; }
    public int Status { get; init; }
    public bool IsDeleted { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
    public DateTimeOffset LastModifiedDate { get; init; }
}