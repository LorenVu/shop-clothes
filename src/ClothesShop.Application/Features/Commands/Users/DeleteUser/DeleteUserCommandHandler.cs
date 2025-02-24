using BuildingBlock.Shared.Configs;
using BuildingBlock.Shared.Seeds;
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
            return ApiFailedResult<bool>.Instance.WithMessage(CodeResponseMessage.DataNotFound);

        //userRepository.DeleteUserAsync(customerEntity);

        customerEntity.IsDeleted = true;
        await userRepository.UpdateAsync(customerEntity);
        var result = await userRepository.SaveChangesAsync(cancellationToken);

        return ApiSuccessResult<bool>.Instance.WithData(result > 0);
    }
}