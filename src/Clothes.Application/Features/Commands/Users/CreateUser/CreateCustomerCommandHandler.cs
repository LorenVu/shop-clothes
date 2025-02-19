using AutoMapper;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clothes.Application.Features.Commands.Users.CreateUser;

public class CreateCustomerCommandHandler(IUserRepository uerRepository, ILogger<CreateUserCommand> logger, IMapper mapper)
    : IRequestHandler<CreateUserCommand, ApiResult<Guid>>
{
    public async Task<ApiResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<User>(request);
        var result = await uerRepository.AddAsync(customer);

        return ApiSuccessResult<Guid>.Instance.WithData(result);
    }
}