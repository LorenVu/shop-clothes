using System.Text;
using AutoMapper;
using MediatR;
using MinimalApi.Application.Common.Dtos;
using MinimalApi.Domain.Configs;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalApi.Application.Features.Queries;

public class GetTransactionQueryHandler(ITransactionRepository transactionRepository,
    SepayConfig sepayConfig, IMapper mapper) : IRequestHandler<GetTransactionQuery, IEnumerable<TransactionDto>>
{
    public async Task<IEnumerable<TransactionDto>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var urlStringBuilder = new StringBuilder($"{sepayConfig.BaseUrl}/{sepayConfig.TransactionEndpoints.BaseEndpoint}/{sepayConfig.TransactionEndpoints.List}");

        // if (request is not null)
        //     urlStringBuilder.Append(GenerateQueryPath(request));

        var url = urlStringBuilder.ToString();
        
        var transactions = await transactionRepository.GetTransactionsAsync(url, cancellationToken);
        var result = mapper.Map<IEnumerable<TransactionDto>>(transactions);
        
        return result;
    }

    private string GenerateQueryPath(GetTransactionQuery request)
    {
        var stringBuilder = new StringBuilder("?");
     
        void AppendIfValid<T>(string paramName, T value, Func<T, bool> condition)
        {
            if (condition(value))
                stringBuilder.Append($"&{paramName}={value}");
        }

        var filter = request.Filter;
        
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
    }
}