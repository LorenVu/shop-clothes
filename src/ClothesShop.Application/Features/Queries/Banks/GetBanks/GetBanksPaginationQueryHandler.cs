using BuildingBlock.Shared.Seeds;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Clothes.Application.Features.Queries.Banks.GetBanks;

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