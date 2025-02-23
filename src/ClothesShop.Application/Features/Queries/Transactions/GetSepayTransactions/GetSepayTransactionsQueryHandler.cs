using System.Text;
using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Services.Interfaces;
using Clothes.Domain.Configs;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using FluentValidation;
using MediatR;

namespace Clothes.Application.Features.Queries.Transactions.GetSepayTransactions;

public class GetSepayTransactionsQueryHandler(
    ISepayTransactionService sepayTransactionService,
    IValidator<GetSepayTransactionsQuery> validator,
    SepayConfigs sepayConfigs, 
    IMapper mapper) : IRequestHandler<GetSepayTransactionsQuery, ApiSuccessResult<PagedResponse<SepayTransactionDto>>>
{
    public async Task<ApiSuccessResult<PagedResponse<SepayTransactionDto>>> Handle(GetSepayTransactionsQuery request, CancellationToken cancellationToken)
    { 
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var urlStringBuilder = new StringBuilder($"{sepayConfigs.BaseUrl}/{sepayConfigs.TransactionEndpoints.BaseEndpoint}/{sepayConfigs.TransactionEndpoints.List}");
        urlStringBuilder.Append(GenerateQueryPath(request));

        var url = urlStringBuilder.ToString();
        var transactions = await sepayTransactionService.GetTransactionsAsync(url, cancellationToken);
        var result = mapper.Map<IEnumerable<SepayTransactionDto>>(transactions);
        var pagedList = new PagedList<SepayTransactionDto>(result, result.Count(), request.PageIndex, request.PageSize);
        
        return ApiSuccessResult<PagedResponse<SepayTransactionDto>>.Instance
            .WithMessage()
            .WithData(new PagedResponse<SepayTransactionDto>(pagedList));
    }

    private static string GenerateQueryPath(GetSepayTransactionsQuery request)
    {
        var stringBuilder = new StringBuilder("?");

        var filter = request.Filter;
        if (filter == null) return stringBuilder.ToString().TrimStart('&');

        if (!string.IsNullOrWhiteSpace(filter.AccountNumber))
            stringBuilder.Append($"&account_number={filter.AccountNumber}");

        AppendIfValid("limit", filter.Limit, x => x > 0);
        AppendIfValid("amount_in", filter.AmountIn, x => x > 0);
        AppendIfValid("amount_out", filter.AmountOut, x => x > 0);
        AppendIfValid("reference_number", filter.ReferenceNumber, x => x > 0);
        AppendIfValid("transaction_date_min", filter.TransactionDateMin,
            x => x > DateTimeOffset.MinValue);
        AppendIfValid("transaction_date_max", filter.TransactionDateMax,
            x => x > DateTimeOffset.MinValue);

        if (filter.TransactionDateMin > DateTimeOffset.MinValue)
            stringBuilder.Append($"&transaction_date_min={filter.TransactionDateMin:yyyy-MM-dd HH:mm:ss}");

        if (filter.TransactionDateMax > DateTimeOffset.MinValue)
            stringBuilder.Append($"&transaction_date_max={filter.TransactionDateMax:yyyy-MM-dd HH:mm:ss}");

        return stringBuilder.ToString().TrimStart('&');

        void AppendIfValid<T>(string paramName, T value, Func<T, bool> condition)
        {
            if (condition(value))
                stringBuilder.Append($"&{paramName}={value}");
        }
    }
}