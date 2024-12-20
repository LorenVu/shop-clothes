using MediatR;
using MinimalApi.Application.Common.Map;
using MinimalApi.Application.Features.Common;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommand : CreateOrUpdateCustomerCommand, IRequest<ApiResult<Customer>>, IMapFrom<Customer>
{
    public long Id { get; set; }
}