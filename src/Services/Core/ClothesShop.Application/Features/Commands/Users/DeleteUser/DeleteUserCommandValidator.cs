using FluentValidation;

namespace Clothes.Application.Features.Commands.Users.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(customer => customer.Id)
            // .Matches(@"^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$")
            // .WithMessage("{PropertyName} invalid Guid format")
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}