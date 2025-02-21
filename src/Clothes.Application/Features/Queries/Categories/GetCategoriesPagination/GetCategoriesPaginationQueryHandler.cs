using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetCategoriesPagination;

public class GetCategoriesPaginationQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoriesPaginationQuery, ApiResult<PagedList<CategoryDto>>>
{
    public async Task<ApiResult<PagedList<CategoryDto>>> Handle(GetCategoriesPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = await categoryRepository.GetCategoriesPagination(
            c=> c.Id,
            c=> c.Name,
            c=> c.Code,
            c=> c.ParentId,
            c=> c.SortOrder,
            c=> c.Status,
            c=> c.IsDeleted,
        );
        
        var categories =  await PagedList<Category>.ToPagedList(queryable, request.PageIndex, request.PageSize);

        var result = mapper.Map<PagedList<CategoryDto>>(categories);
        return ApiSuccessResult<PagedList<CategoryDto>>.Instance.WithMessage().WithData(result);
    }
}