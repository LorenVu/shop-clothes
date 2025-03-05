using FluentValidation;

namespace Clothes.Application.Features.Commands.Banks.DeleteBank;

public class DeleteBankCommandValidation : AbstractValidator<DeleteBankCommand>
{
    public DeleteBankCommandValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must greater than 0");
    }
}