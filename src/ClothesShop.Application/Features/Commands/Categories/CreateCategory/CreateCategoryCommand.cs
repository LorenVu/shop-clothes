using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Mappings;
using Clothes.Application.Features.Commands.Categories.Common;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;

namespace Clothes.Application.Features.Commands.Categories.CreateCategory;

public record CreateCategoryCommand : CreateOrUpdateCategoryCommand, IMapFrom<Category>, IRequest<ApiResult<long>>;