using MediatR;
using MinimalApi.Application.Common.Extensions;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Seeds;

namespace MinimalApi.Application.Features;

public class GetBanksPaginationQueryHandler(IBankRepository bankRepository)
    : IRequestHandler<GetBanksPaginationQuery, PagedList<Bank>>
{
    public async Task<PagedList<Bank>> Handle(GetBanksPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = bankRepository.GetAllAsync();

        // if (request.Filters is { Count: > 0 })
        //     queryable.Filtering(request.Filters);
        //
        // if (request.Orders is { Count: > 0 })
        //     queryable.Ordering(request.Orders);

        return await PagedList<Bank>.ToPagedList(queryable, request.PageIndex, request.PageSize);
    }
}