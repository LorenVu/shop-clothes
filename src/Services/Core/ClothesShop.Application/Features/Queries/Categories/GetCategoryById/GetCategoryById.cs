using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Queries.Categories.GetCategoryById;

public record GetCategoryById(long Id) : IRequest<ApiResult<CategoryDto>>;