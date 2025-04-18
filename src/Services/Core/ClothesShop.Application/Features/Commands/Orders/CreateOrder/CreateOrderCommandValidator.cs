using Clothes.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Clothes.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;
    
    public CreateOrderCommandValidator(IServiceProvider serviceProvider)
    {
        _customerRepository = serviceProvider.GetRequiredService<ICustomerRepository>();
        
        RuleFor(x => x.PhoneNumber)
            .Matches(@"/^\d+$/")
            .WithMessage("Phone number isn't number");

        When(x => x.CustomerId.HasValue, () =>
        {
            RuleFor(x => x.CustomerId)
                .CustomAsync(ValidateCustomerId);
        });
    }

    private async Task ValidateCustomerId(Guid? customerId, ValidationContext<CreateOrderCommand> context, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindByIdAsync(customerId!.Value);
        
        
        
    }
}