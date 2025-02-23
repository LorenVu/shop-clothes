using Clothes.Application.Common.Dtos;
using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;
using Clothes.Domain.Enums;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Requests;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetCategoriesPagination;

public class GetCategoriesPaginationQuery : QueryBase<GetCategoriesFilter, GetCategoriesOrder>, IMapFrom<Category>, IRequest<ApiResult<PagedResponse<CategoryDto>>>
{
    
}

public sealed class GetCategoriesFilter : FilterCondition
{
    public string? Name { get; init; }
    public string? Code { get; init; }
    public int? ParentId { get; init; }
    public int? Status { get; init; }
    public bool? IsDeleted { get; init; }
    public DateTimeOffset? FromDate { get; init; }
    public DateTimeOffset?ToDate { get; init; }
}

public sealed class GetCategoriesOrder : OrderCondition
{
    public ESort Id { get; init; }
    public ESort Name { get; init; }
    public ESort Code { get; init; }
    public ESort ParentId { get; init; }
    public ESort Status { get; init; }
    public ESort IsDeleted { get; init; }
    public ESort CreatedDate { get; init; }
    public ESort LastModifiedDate { get; init; }
}
