using MediatR;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalApi.Application.Features.Queries.GetUserById;

public class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        => await customerRepository.FindByIdAsync(request.Id);
        
    
}