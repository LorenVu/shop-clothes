using Clothes.Application.Common.Dtos;
using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Requests;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetCategoriesPagination;

public class GetCategoriesFilter : FilterCondition
{
    
}

public class GetCategoriesOrder : OrderCondition
{
    
}


public class GetCategoriesPaginationQuery : QueryBase<GetCategoriesFilter, GetCategoriesOrder>, IMapFrom<Category>, IRequest<ApiResult<PagedList<CategoryDto>>>
{
    
}