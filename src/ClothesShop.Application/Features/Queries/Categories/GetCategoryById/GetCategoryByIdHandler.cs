using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Configs;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetCategoryById;

public class GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryById, ApiResult<CategoryDto>>
{
    public async Task<ApiResult<CategoryDto>> Handle(GetCategoryById request, CancellationToken cancellationToken)
    {
        var categoryById = await categoryRepository.GetCategoryByIdAsync(request.Id);
        var categoryDto = mapper.Map<CategoryDto>(categoryById);
        
        return categoryById is not null
            ? ApiSuccessResult<CategoryDto>.Instance.WithMessage().WithData(categoryDto)
            : ApiFailedResult<CategoryDto>.Instance.WithMessage(CodeResponseMessage.DataNotFound);
    }
}