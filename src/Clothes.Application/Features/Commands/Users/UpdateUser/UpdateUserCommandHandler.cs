using AutoMapper;
using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Users;

public class UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, ApiResult<User>>
{
    public async Task<ApiResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await userRepository.FindByIdAsync(request.Id);
        
        if(userEntity == null) return ApiFailedResult<User>.Instance.WithMessage($"");
        
        var user = mapper.Map<User>(request);
        await userRepository.UpdateAsync(user);
        var result = await userRepository.SaveChangesAsync();
        
        return ApiSuccessResult<User>
            .Instance
            .WithData(user);
    }
}