using MediatR;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Features.Queries.GetUserById;

public class GetCustomerByIdQuery : IRequest<Customer>
{
    private long _id;

    public long Id
    {
        get => _id; 
        set => _id = value;
    }
}