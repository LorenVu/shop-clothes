using FluentValidation;

namespace MinimalApi.Application.Features.Queries.GetUserById;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}