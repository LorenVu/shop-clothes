using MinimalApi.Application.Common.Map;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Features.Common;

public abstract class CreateOrUpdateCustomerCommand : IMapFrom<Customer>
{
    public string CustomerName { get; set; }
    public string FullName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public int TempId { get; set; }
    public int Type { get; set; }
    public string Evident { get; set; }
    public string License { get; set; }
}