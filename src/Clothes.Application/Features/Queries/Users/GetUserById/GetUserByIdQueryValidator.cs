using FluentValidation;

namespace Clothes.Application.Features.Queries.Users.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        // RuleFor(x => x.Id)
        //     .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}