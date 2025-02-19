using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Requests;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetCustomers;

public sealed class GetUsersPaginationQuery :
    QueryBase<FilterCondition, OrderCondition>,
    IRequest<PagedList<UserDto>>
{
    public string? UserName { get; init; }
    public string? EmailAddress { get; init; }
    public int IsActive { get; init; }
    public bool IsDeleted { get; init; }
}