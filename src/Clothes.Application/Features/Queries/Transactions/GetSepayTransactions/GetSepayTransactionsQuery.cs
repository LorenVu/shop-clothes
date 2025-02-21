using System.Text.Json.Serialization;
using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;
using Clothes.Domain.Enums;
using Clothes.Infrastructure.Shared.Requests;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Transactions.GetSepayTransactions;

public sealed class TransactionFilterCondition : FilterCondition
{
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("transaction_date_min")]
    public DateTimeOffset TransactionDateMin { get; init; } = DateTimeOffset.Now.AddDays(-30);

    [JsonPropertyName("transaction_date_max")]
    public DateTimeOffset TransactionDateMax { get; init; } = DateTimeOffset.Now;

    [JsonPropertyName("since_id")]
    public int SinceId { get; init; }

    [JsonPropertyName("limit")]
    public int Limit { get; init; }

    [JsonPropertyName("reference_number")]
    public long ReferenceNumber { get; init; }

    [JsonPropertyName("amount_in")]
    public int AmountIn { get; init; }

    [JsonPropertyName("amount_out")]
    public int AmountOut { get; init; }
}

public class TransactionOrderCondition : OrderCondition
{
    public ESort CreatedDatetime { get; set; }
    public ESort AmountOut { get; set; }
    public ESort AmountIn { get; set; }
    public ESort TransactionDateMin { get; set; }
    public ESort TransactionDateMax { get; set; }
}

public class GetSepayTransactionsQuery : QueryBase<TransactionFilterCondition, TransactionOrderCondition>, IMapFrom<SepayTransactionDto>, IRequest<ApiSuccessResult<IEnumerable<SepayTransactionDto>>>
{
    public void Mapping(Profile profile) =>
        profile.CreateMap<SepayTransaction, SepayTransactionDto>();
}