using BuildingBlock.Shared.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Banks.DeleteBank;

public record DeleteBankCommand(int Id) : IRequest<ApiResult<bool>>;
