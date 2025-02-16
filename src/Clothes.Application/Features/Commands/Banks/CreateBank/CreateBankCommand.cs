using MediatR;
using MinimalApi.Application.Common.Map;
using MinimalApi.Application.Features.Common.Banks;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Banks.CreateBank;

public class CreateBankCommand : CreateAndUpdateBankCommand, IRequest<ApiResult<int>>, IMapFrom<CreateBankCommand>
{
    
}