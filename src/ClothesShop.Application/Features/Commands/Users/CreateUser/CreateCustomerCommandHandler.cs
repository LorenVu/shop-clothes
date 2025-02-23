using Clothes.Application.Services.Interfaces;
using Clothes.Domain.Configs;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using FluentValidation;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.CreateUser;

public class CreateCustomerCommandHandler(IUserRepository uerRepository, IIdentityService identityService, IValidator<CreateUserCommand> validator)
    : IRequestHandler<CreateUserCommand, ApiResult<Guid>>
{
    public async Task<ApiResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var salt = identityService.GenerateSalt();
        var password = identityService.HashPassword(request.Password, salt);
        
        var customer = new User(request.UserName ?? "member", password, salt)
        {
            Id = Guid.NewGuid(),
            EmailAddress = request.EmailAddress ?? string.Empty,
            FullName = request.FullName,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await uerRepository.AddAsync(customer);
        var result = await uerRepository.SaveChangesAsync(cancellationToken);

        return result > 0 
            ? ApiSuccessResult<Guid>.Instance.WithMessage().WithData(customer.Id)
            : ApiFailedResult<Guid>.Instance.WithMessage(CodeResponseMessage.Failed);
    }
}