using BuildingBlock.Shared.Enums.Common;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Shared.Requests;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetCustomers;

public sealed class GetUsersPaginationQuery :
    QueryBase<UserPaginationFilter, UserPaginationOrder>,
    IRequest<ApiSuccessResult<PagedList<UserDto>>>
{
}

public sealed class UserPaginationFilter : FilterCondition
{
    public string? UserName { get; init; }
    public string? FullName { get; init; }
    public string? EmailAddress { get; init; }
    public int? Status { get; init; }
    public bool? IsDeleted { get; init; }
    public DateTimeOffset? FromDate { get; init; }
    public DateTimeOffset? ToDate { get; init; }
}

public sealed class UserPaginationOrder : OrderCondition
{
    public ESort? UserName { get; init; }
    public ESort? FullName { get; init; }
    public ESort? EmailAddress { get; init; }
    public ESort? Status { get; init; }
    public ESort? IsDeleted { get; init; }
    public ESort? CreatedDate { get; init; }
    public ESort? LastModifiedDate { get; init; }
}
