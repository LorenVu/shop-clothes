namespace Clothes.Application.Features.Commands.Categories.Common;

public record class CreateOrUpdateCategoryCommand
{
    public string? Name { get; init; }

    public string? Code { get; init; }
    
    public string? Icon { get; init; }

    public int ParentId { get; init; }

    public int SortOrder { get; init; }
    
    public int IsActive { get; init; }

    public bool IsDeleted { get; init; }
}