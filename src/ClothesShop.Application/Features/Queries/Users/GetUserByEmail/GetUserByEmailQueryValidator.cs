using FluentValidation;

namespace Clothes.Application.Features.Queries.Users.GetUserByEmail;

public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address");
    }
}