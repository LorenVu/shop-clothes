using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ICustomerRepository : IRepositoryBaseAsync<Customer, Guid, ApplicationDbContext>
{
     
}