using Clothes.Domain.Configs;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Banks.DeleteBank;

public class DeleteBankCommandHandler(IBankRepository bankRepository) : IRequestHandler<DeleteBankCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        var bankEntity = await bankRepository.FindByIdAsync(request.Id);

        if (bankEntity == null)
            return ApiFailedResult<bool>.Instance.WithMessage(CodeResponseMessage.DataNotFound);

        bankRepository.DeleteBankAsync(bankEntity);
        var result = await bankRepository.SaveChangesAsync(cancellationToken);

        return result > 0
            ? ApiSuccessResult<bool>.Instance.WithData(true)
            : ApiFailedResult<bool>.Instance.WithMessage(CodeResponseMessage.Failed);
    }
}