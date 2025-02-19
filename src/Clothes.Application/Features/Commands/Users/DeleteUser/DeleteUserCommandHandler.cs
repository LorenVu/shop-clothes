using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.DeleteUser;


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