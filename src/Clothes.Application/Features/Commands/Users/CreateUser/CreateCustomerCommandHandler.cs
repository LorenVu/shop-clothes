using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;

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