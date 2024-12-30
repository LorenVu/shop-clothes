using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, ILogger<CreateCustomerCommand> logger, IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, ApiResult<long>>
{
    public async Task<ApiResult<long>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(request);
        var result = await customerRepository.CreateAsync(customer);
        
        return ApiSuccessResult<long>.Instance.WithData(result);
    }
}