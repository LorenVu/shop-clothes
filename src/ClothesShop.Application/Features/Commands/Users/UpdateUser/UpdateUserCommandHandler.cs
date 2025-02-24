using AutoMapper;
using BuildingBlock.Shared.Configs;
using BuildingBlock.Shared.Contracts.Identity;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Services.Interfaces;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository, IIdentityService identityService, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, ApiResult<UserDto>>
{
    public async Task<ApiResult<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await userRepository.FindByIdAsync(request.Id);

        if (existUser == null) return ApiFailedResult<UserDto>.Instance.WithMessage(CodeResponseMessage.DataNotFound);

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            var newPassword = identityService.HashPassword(existUser.Salt, request.Password);
            existUser.ChangePassword(newPassword);
        }
        
        if (!string.IsNullOrWhiteSpace(request.EmailAddress))
            existUser.ChangeEmail(request.EmailAddress);
        
        if (!string.IsNullOrWhiteSpace(request.UserName))
            existUser.ChangeUsername(request.UserName);
        
        await userRepository.UpdateAsync(existUser);
        var result = await userRepository.SaveChangesAsync(cancellationToken);

        if (result <= 0)
            return ApiFailedResult<UserDto>
                .Instance
                .WithMessage(CodeResponseMessage.Failed);
        
        var userDto = mapper.Map<UserDto>(existUser);
        return ApiSuccessResult<UserDto>
            .Instance
            .WithMessage()
            .WithData(userDto);

    }
}