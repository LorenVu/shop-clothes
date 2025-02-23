using FluentValidation;

namespace Clothes.Application.Features.Commands.Users.CreateUser;

public class CreateCustomerCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(50).WithMessage("{PropertyName} cannot be more than 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(100).WithMessage("{PropertyName} cannot be more than 100 characters")
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address");
    }
}