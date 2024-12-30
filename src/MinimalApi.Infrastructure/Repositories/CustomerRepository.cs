using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Persistences;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalProject.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer, long>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
        await GetAllAsync().ToListAsync();


    public async Task<Customer?> GetCustomerByIdAsync(long id) =>
        await FindByIdAsync(id);

    public async Task<Customer> CreateCustomerAsync(Customer Customer)
    {
        await CreateAsync(Customer);
        await SaveChangesAsync();
        
        return Customer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer Customer)
    {
        await UpdateAsync(Customer);
        await SaveChangesAsync();
        
        return Customer;
    }

    public Task DeleteCustomerAsync(Customer Customer) =>
        DeleteAsync(Customer);
    
}