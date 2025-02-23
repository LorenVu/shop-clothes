using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Entities;
using Clothes.Domain.Enums;
using Clothes.Domain.Extensions;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Clothes.Application.Features.Queries.Categories.GetCategoriesPagination;

public class GetCategoriesPaginationQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoriesPaginationQuery, ApiResult<PagedResponse<CategoryDto>>>
{
    public async Task<ApiResult<PagedResponse<CategoryDto>>> Handle(GetCategoriesPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = await categoryRepository.GetCategoriesPaginationAsync();
        BuildQuery(ref queryable, request.Filter, request.Order);

        var result =  await PagedList<CategoryDto>.ToPagedListAsync(
            queryable.OrderByDescending(c => c.Id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    ParentId = c.ParentId,
                    SortOrder = c.SortOrder,
                    Status = c.Status,
                    IsDeleted = c.IsDeleted,
                    CreatedDate = c.CreatedDate,
                    LastModifiedDate = c.LastModifiedDate
                }), 
                pageIndex: request.PageIndex, 
                pageNumber: request.PageSize,
                cancellationToken);

        return ApiSuccessResult<PagedResponse<CategoryDto>>.Instance
            .WithMessage()
            .WithData(new PagedResponse<CategoryDto>(result));
    }

    private static void BuildQuery(ref IQueryable<Category> queryable, GetCategoriesFilter? filter, GetCategoriesOrder? order)
    {
        if (filter is not null)
            ApplyFilter(ref queryable, filter);
           
        if (order is not null)
            ApplyOrder(ref queryable, order);
    }

    private static void ApplyFilter(ref IQueryable<Category> queryable, GetCategoriesFilter filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.Name))
            queryable = queryable.Where(c => c.Name.Contains(filter.Name));
            
        if (!string.IsNullOrWhiteSpace(filter.Code))
            queryable = queryable.Where(c => c.Code.Contains(filter.Code));
            
        if (filter.ParentId.HasValue && filter.ParentId != 0)
            queryable = queryable.Where(c => c.ParentId == filter.ParentId);
            
        if (filter.Status.HasValue && filter.Status != 0)
            queryable = queryable.Where(c => c.Status == filter.Status);
            
        if (filter.IsDeleted.HasValue)
            queryable = queryable.Where(c => c.IsDeleted == filter.IsDeleted);
        
        if (filter.FromDate.HasValue && filter.FromDate > DateTimeOffset.MinValue)
            queryable = queryable.Where(c => c.CreatedDate >= filter.FromDate);
        
        if (filter.ToDate.HasValue && filter.ToDate > DateTimeOffset.MinValue)
            queryable = queryable.Where(c => c.CreatedDate <= filter.ToDate);
    }

    private static void ApplyOrder(ref IQueryable<Category> queryable, GetCategoriesOrder order)
    {
        if (order.Id != ESort.NoSort)
            queryable = order.Id == ESort.Ascending 
                ? queryable.OrderBy(c => c.Id)
                : queryable.OrderByDescending(c => c.Id);
        
        if (order.Name != ESort.NoSort)
            queryable = order.Name == ESort.Ascending 
                ? queryable.OrderBy(c => c.Name)
                : queryable.OrderByDescending(c => c.Name);
            
        if (order.Code != ESort.NoSort)
            queryable = order.Code == ESort.Ascending 
                ? queryable.OrderBy(c => c.Code)
                : queryable.OrderByDescending(c => c.Code);
                        
        if (order.ParentId != ESort.NoSort)
            queryable = order.ParentId == ESort.Ascending 
                ? queryable.OrderBy(c => c.ParentId)
                : queryable.OrderByDescending(c => c.ParentId);
            
        if (order.Status != ESort.NoSort)
            queryable = order.Status == ESort.Ascending 
                ? queryable.OrderBy(c => c.Status)
                : queryable.OrderByDescending(c => c.Status);
            
        if (order.IsDeleted != ESort.NoSort)
            queryable = order.IsDeleted == ESort.Ascending 
                ? queryable.OrderBy(c => c.IsDeleted)
                : queryable.OrderByDescending(c => c.IsDeleted);
        
        if (order.CreatedDate != ESort.NoSort)
            queryable = order.CreatedDate == ESort.Ascending 
                ? queryable.OrderBy(c => c.CreatedDate)
                : queryable.OrderByDescending(c => c.CreatedDate);
        
        if (order.LastModifiedDate != ESort.NoSort)
            queryable = order.LastModifiedDate == ESort.Ascending 
                ? queryable.OrderBy(c => c.LastModifiedDate)
                : queryable.OrderByDescending(c => c.LastModifiedDate);
    }

}