using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Seeds;

namespace MinimalApi.Application.Features;

public class GetCustomersPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetCustomersPaginationQuery, PagedList<User>>
{
    public async Task<PagedList<User>> Handle(GetCustomersPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = userRepository.GetAllAsync();

        // if (request.Filters is { Count: > 0 })
        //     queryable.Filtering(request.Filters);
        //
        // if (request.Orders is { Count: > 0 })
        //     queryable.Ordering(request.Orders);

        return await PagedList<User>.ToPagedList(queryable, request.PageIndex, request.PageSize);
    }
}