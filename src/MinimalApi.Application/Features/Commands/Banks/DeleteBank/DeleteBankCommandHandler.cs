using MediatR;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared;

namespace MinimalApi.Application.Features.Commands.Banks.DeleteBank;

public class DeleteBankCommandHandler(IBankRepository bankRepository) : IRequestHandler<DeleteBankCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        var bankEntity = await bankRepository.FindByIdAsync(request.Id);

        if (bankEntity == null)
            return ApiFailedResult<bool>.Instance.WithMessage($"Bank with Id: {request.Id} does not exist");
        
        bankRepository.DeleteBankAsync(bankEntity);
        var result = await bankRepository.SaveChangesAsync();

        return result > 0 
            ? ApiSuccessResult<bool>.Instance.WithData(true)
            : ApiFailedResult<bool>.Instance.WithMessage("Failed");
    }
}