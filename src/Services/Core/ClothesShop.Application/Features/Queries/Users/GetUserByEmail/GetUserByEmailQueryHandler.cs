using Clothes.Domain.Entities;
using Clothes.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetUserByEmail;

public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, User?>
{
    public Task<User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken) =>
        userRepository.GetUserByEmailAsync(request.Email);
}