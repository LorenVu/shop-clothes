using Clothes.Domain.Entities;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Requests;
using MediatR;

namespace Clothes.Application.Features.Queries.Banks.GetBanks;

public class GetBanksPaginationQuery :
    QueryPagingBase,
    IRequest<PagedList<Bank>>
{

}