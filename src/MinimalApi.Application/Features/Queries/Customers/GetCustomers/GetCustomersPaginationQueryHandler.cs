using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Seeds;

namespace MinimalApi.Application.Features;

public class GetCustomersPaginationQueryHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomersPaginationQuery, PagedList<Customer>>
{
    public async Task<PagedList<Customer>> Handle(GetCustomersPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = customerRepository.GetAllAsync();

        // if (request.Filters is { Count: > 0 })
        //     queryable.Filtering(request.Filters);
        //
        // if (request.Orders is { Count: > 0 })
        //     queryable.Ordering(request.Orders);

        return await PagedList<Customer>.ToPagedList(queryable, request.PageIndex, request.PageSize);
    }
}