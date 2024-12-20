using MediatR;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.DeleteUser;

public class DeleteCustomerCommand : IRequest<ApiResult<bool>>
{
    public long Id { get; private set; }
}