using FluentValidation;

namespace MinimalApi.Application.Features.Commands.DeleteUser;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");        
    }
}