using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Seeds;
using MinimalApi.Infrastructure.Shared.Requests;

namespace MinimalApi.Application.Features;

public class GetCustomersPaginationQuery : 
    QueryBase<FilterCondition,OrderCondition>,  
    IRequest<PagedList<User>>
{
 
}