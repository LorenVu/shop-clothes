using AutoMapper;
using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<UpdateCustomerCommand, ApiResult<Customer>>
{
    public async Task<ApiResult<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var CustomerEntity = await customerRepository.FindByIdAsync(request.Id);
        
        if(CustomerEntity == null) return ApiFailedResult<Customer>.Instance.WithMessage($"");
        
        var Customer = mapper.Map<Customer>(request);
        
        await customerRepository.UpdateAsync(Customer);
        var result = await customerRepository.SaveChangesAsync();
        
        return ApiSuccessResult<Customer>.Instance
                                    .WithData(Customer);
    }
}