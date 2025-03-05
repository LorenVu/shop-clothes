using BuildingBlock.Shared.Enums.Common;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetCustomers;

public class GetUsersPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUsersPaginationQuery, ApiSuccessResult<PagedList<UserDto>>>
{
    public async Task<ApiSuccessResult<PagedList<UserDto>>> Handle(GetUsersPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = userRepository
            .GetAllAsync();
        
        BuildQuery(ref queryable, request.Filter, request.Order);
        
        var result = await PagedList<UserDto>
            .ToPagedListAsync(queryable
                .OrderByDescending(u => u.Id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Password = u.Password,
                    FullName = u.FullName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PictureUrl = u.PictureUrl,
                    EmailAddress = u.EmailAddress,
                    IsDeleted = u.IsDeleted,
                    Status = u.Status
                }), request.PageIndex, request.PageSize, cancellationToken);

        return ApiSuccessResult<PagedList<UserDto>>.Instance.WithMessage().WithData(result);
    }

    private void BuildQuery(ref IQueryable<User> queryable, UserPaginationFilter? filters, UserPaginationOrder? orders)
    {
        if (filters is not null)
            ApplyFilter(ref queryable, filters);
        
        if (orders is not null)
           ApplyOrdering(ref queryable, orders);
    }
    
    private void ApplyFilter(ref IQueryable<User> queryable, UserPaginationFilter filters)
    {
        if (!string.IsNullOrEmpty(filters.UserName))
            queryable = queryable.Where(u => u.UserName.Contains(filters.UserName));
        
        if (!string.IsNullOrEmpty(filters.FullName))
            queryable = queryable.Where(u => u.FullName != null && u.FullName.Contains(filters.FullName));
        
        if (!string.IsNullOrEmpty(filters.EmailAddress))
            queryable = queryable.Where(u => u.EmailAddress.Contains(filters.EmailAddress));
        
        if (filters.Status is > 0)
            queryable = queryable.Where(u => u.Status == filters.Status);
        
        if (filters.IsDeleted.HasValue)
            queryable = queryable.Where(u => u.IsDeleted == filters.IsDeleted);
        
        if (filters.FromDate.HasValue && filters.FromDate > DateTimeOffset.MinValue)
            queryable = queryable.Where(u => u.CreatedDate >= filters.FromDate);
        
        if (filters.ToDate.HasValue && filters.ToDate > DateTimeOffset.MinValue)
            queryable = queryable.Where(u => u.CreatedDate <= filters.ToDate);
    }

    private void ApplyOrdering(ref IQueryable<User> queryable, UserPaginationOrder orders)
    {
        if (orders.UserName.HasValue && orders.UserName != ESort.NoSort)
            queryable = orders.UserName == ESort.Ascending
                ? queryable.OrderBy(u => u.UserName)
                : queryable.OrderByDescending(u => u.UserName);
        
        if (orders.FullName.HasValue && orders.FullName != ESort.NoSort)
            queryable = orders.FullName == ESort.Ascending
                ? queryable.OrderBy(u => u.FullName)
                : queryable.OrderByDescending(u => u.FullName);
        
        if (orders.EmailAddress.HasValue && orders.EmailAddress != ESort.NoSort)
            queryable = orders.EmailAddress == ESort.Ascending
                ? queryable.OrderBy(u => u.EmailAddress)
                : queryable.OrderByDescending(u => u.EmailAddress);
        
        if (orders.Status.HasValue && orders.Status != ESort.NoSort)
            queryable = orders.Status == ESort.Ascending
                ? queryable.OrderBy(u => u.Status)
                : queryable.OrderByDescending(u => u.Status);
        
        if (orders.IsDeleted.HasValue && orders.IsDeleted != ESort.NoSort)
            queryable = orders.IsDeleted == ESort.Ascending
                ? queryable.OrderBy(u => u.IsDeleted)
                : queryable.OrderByDescending(u => u.IsDeleted);
        
        if (orders.CreatedDate.HasValue && orders.CreatedDate != ESort.NoSort)
            queryable = orders.CreatedDate == ESort.Ascending
                ? queryable.OrderBy(u => u.CreatedDate)
                : queryable.OrderByDescending(u => u.CreatedDate);
        
        if (orders.LastModifiedDate.HasValue && orders.LastModifiedDate != ESort.NoSort)
            queryable = orders.LastModifiedDate == ESort.Ascending
                ? queryable.OrderBy(u => u.LastModifiedDate)
                : queryable.OrderByDescending(u => u.LastModifiedDate);
    }

    
}