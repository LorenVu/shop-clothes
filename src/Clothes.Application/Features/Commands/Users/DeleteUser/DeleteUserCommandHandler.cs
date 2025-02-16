using MediatR;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;


public class DeleteUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<DeleteUserCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var customerEntity = await userRepository.FindByIdAsync(request.Id);

        if (customerEntity == null)
            return ApiFailedResult<bool>.Instance.WithMessage($"Customer with Id: {request.Id} does not exist");
        
        userRepository.DeleteUserAsync(customerEntity);
        var result = await userRepository.SaveChangesAsync();

        return ApiSuccessResult<bool>.Instance.WithData(result > 0);
    }
}