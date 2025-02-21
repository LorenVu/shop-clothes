using AutoMapper;
using Clothes.Domain.Configs;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, ApiResult<User>>
{
    public async Task<ApiResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await userRepository.FindByIdAsync(request.Id);

        if (userEntity == null) return ApiFailedResult<User>.Instance.WithMessage(CodeResponseMessage.DataNotFound);

        var user = mapper.Map<User>(request);
        await userRepository.UpdateAsync(user);
        var result = await userRepository.SaveChangesAsync(cancellationToken);

        return ApiSuccessResult<User>
            .Instance
            .WithData(user);
    }
}