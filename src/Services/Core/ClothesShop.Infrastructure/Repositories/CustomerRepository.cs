using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;

namespace Clothes.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBaseAsync<Customer, Guid, ApplicationDbContext>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context, IUnitOfWork<ApplicationDbContext> unitOfWork) : base(context, unitOfWork)
    {
    }
    
    
    
}