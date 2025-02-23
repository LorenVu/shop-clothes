using Clothes.Application.Features.Commands.Categories.Common;
using FluentValidation;

namespace Clothes.Application.Features.Commands.Categories.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateOrUpdateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        // RuleFor(c => c.Name)
    }
}