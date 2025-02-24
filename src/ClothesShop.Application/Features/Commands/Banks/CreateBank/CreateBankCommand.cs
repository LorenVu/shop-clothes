using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Mappings;
using Clothes.Application.Features.Common.Banks;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Banks.CreateBank;

public class CreateBankCommand : CreateAndUpdateBankCommand, IRequest<ApiResult<int>>, IMapFrom<CreateBankCommand>
{

}