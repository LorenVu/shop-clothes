using FluentValidation;

namespace Clothes.Application.Features.Queries.Transactions.GetSepayTransactions;

public class GetSepayTransactionsQueryValidator : AbstractValidator<GetSepayTransactionsQuery>
{
    public GetSepayTransactionsQueryValidator()
    {
        RuleFor(x => x.Filter!.Limit)
            .LessThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than zero");
        
        RuleFor(x => x.Filter!.AmountIn)
            .LessThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than zero");
        
        RuleFor(x => x.Filter!.AmountOut)
            .LessThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than zero");
        
        RuleFor(x => x.Filter!.ReferenceNumber)
            .LessThanOrEqualTo(0)   
            .WithMessage("{PropertyName} must be greater than zero");
    }
}