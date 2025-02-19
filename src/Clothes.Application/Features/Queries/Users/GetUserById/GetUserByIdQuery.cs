using Clothes.Application.Common.Dtos;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetUserById;

public class GetUserByIdQuery(Guid id) : IRequest<UserDto?>
{
    private Guid _id = id;

    public Guid Id
    {
        get => _id;
        set => _id = value;
    }
}