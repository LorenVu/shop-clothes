using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetUserById;

public class GetUserByIdQueryHandler(IUserRepository iUserRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await iUserRepository.FindByIdAsync(request.Id);

        return user != null
            ? new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                FullName = user.FullName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PictureUrl = user.PictureUrl,
                EmailAddress = user.EmailAddress,
                IsDeleted = user.IsDeleted,
                Status = user.Status
            }
            : null;
    }


}