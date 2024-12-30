using MediatR;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.DeleteUser;


public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<DeleteCustomerCommand, ApiResult<bool>>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<ApiResult<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerEntity = await _customerRepository.FindByIdAsync(request.Id);

        if (customerEntity == null)
            return ApiFailedResult<bool>.Instance.WithMessage($"Customer with ID: {request.Id} does not exist");
        
        _customerRepository.DeleteCustomerAsync(customerEntity);
        var result = await _customerRepository.SaveChangesAsync();

        return ApiSuccessResult<bool>.Instance.WithData(result > 0);
    }
}