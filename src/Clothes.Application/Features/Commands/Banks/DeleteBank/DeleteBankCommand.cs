using MediatR;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Banks.DeleteBank;

public record DeleteBankCommand(int Id) : IRequest<ApiResult<bool>>;
