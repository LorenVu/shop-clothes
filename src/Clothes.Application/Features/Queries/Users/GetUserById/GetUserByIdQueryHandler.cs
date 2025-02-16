using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalApi.Application.Features.Queries.Users;

public class GetUserByIdQueryHandler(IUserRepository iUserRepository) : IRequestHandler<GetUserByIdQuery, User>
{
    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        => await iUserRepository.FindByIdAsync(request.Id);
        
    
}