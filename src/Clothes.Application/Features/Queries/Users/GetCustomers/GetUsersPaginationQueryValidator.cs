using FluentValidation;

namespace Clothes.Application.Features.Queries.Users.GetCustomers;

public class GetUsersPaginationQueryValidator : AbstractValidator<GetUsersPaginationQuery>
{
    public GetUsersPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than or equal to 1");
        
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than or equal to 1");
        
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address");

        // RuleFor(x => x.IsActive)
        //     .InclusiveBetween(x => 0, 3);
    }
    
}