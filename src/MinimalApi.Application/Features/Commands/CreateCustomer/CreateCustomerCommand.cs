using MediatR;
using MinimalApi.Application.Common.Map;
using MinimalApi.Application.Features.Common;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.CreateCustomer;

public class CreateCustomerCommand : CreateOrUpdateCustomerCommand, IRequest<ApiResult<long>>, IMapFrom<CreateCustomerCommand>
{
    
}