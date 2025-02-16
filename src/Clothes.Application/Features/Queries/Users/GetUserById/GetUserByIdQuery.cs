using MediatR;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Features.Queries.Users;

public class GetUserByIdQuery : IRequest<User>
{
    private Guid _id;

    public Guid Id
    {
        get => _id; 
        set => _id = value;
    }
}