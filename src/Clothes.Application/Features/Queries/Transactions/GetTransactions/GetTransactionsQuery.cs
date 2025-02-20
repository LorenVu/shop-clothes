using System.Text.Json.Serialization;
using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Shared.Requests;
using MediatR;

namespace Clothes.Application.Features.Queries.Transactions.GetTransactions;

public class TransactionFilterCondition : FilterCondition
{
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("transaction_date_min")]
    public DateTimeOffset TransactionDateMin { get; set; } = DateTimeOffset.Now.AddDays(-7);

    [JsonPropertyName("transaction_date_max")]
    public DateTimeOffset TransactionDateMax { get; set; } = DateTimeOffset.Now;

    [JsonPropertyName("since_id")]
    public int SinceId { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("reference_number")]
    public long ReferenceNumber { get; set; }

    [JsonPropertyName("amount_in")]
    public int AmountIn { get; set; }

    [JsonPropertyName("amount_out")]
    public int AmountOut { get; set; }
}

public class GetTransactionsQuery : QueryBase<TransactionFilterCondition, OrderCondition>, IMapFrom<TransactionDto>, IRequest<IEnumerable<TransactionDto>>
{
    public void Mapping(Profile profile) =>
        profile.CreateMap<SepayTransaction, TransactionDto>();
}