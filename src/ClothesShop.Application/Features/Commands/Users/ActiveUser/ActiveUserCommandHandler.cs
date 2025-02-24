using BuildingBlock.Shared.Configs;
using BuildingBlock.Shared.Seeds;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.ActiveUser;

public class ActiveUserCommandHandler(IUserRepository userRepository) : IRequestHandler<ActiveUserCommand, ApiResult<object>>
{
    public async Task<ApiResult<object>> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await userRepository.FindByIdAsync(request.Id);
        
        if(existUser == null)
            return ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.DataNotFound);

        existUser.IsDeleted = !existUser.IsDeleted;
        await userRepository.UpdateAsync(existUser);
        var result = await userRepository.SaveChangesAsync(cancellationToken);
        
        return result > 0 
            ? ApiSuccessResult<object>.Instance.WithMessage() 
            : ApiFailedResult<object>.Instance.WithMessage(CodeResponseMessage.Failed);
    }
}