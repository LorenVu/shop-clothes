using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetHierarchyCategories;

public class CategoryHierarche
{ 
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Icon { get; init; }
    public int ParentId { get; init; }
    public int SortOrder { get; init; }
    public List<CategoryHierarche> Childs { get; set; } = [];
}

public record GetHierarchyCategoriesQuery(string? Name, string? Code) : IRequest<ApiResult<List<CategoryHierarche>>>;