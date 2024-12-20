using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Repositories.Interfaces;

public interface ICustomerRepository : IRepositoryBase<Customer, long>
{
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(long id);
    Task<Customer> CreateCustomerAsync(Customer Customer);
    Task<Customer> UpdateCustomerAsync(Customer Customer);
    Task DeleteCustomerAsync(Customer Customer);
}