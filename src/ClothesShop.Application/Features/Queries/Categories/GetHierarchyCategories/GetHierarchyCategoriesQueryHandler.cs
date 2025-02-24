using AutoMapper;
using BuildingBlock.Shared.Seeds;
using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Application.Features.Queries.Categories.GetHierarchyCategories;

public class GetHierarchyCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) 
    : IRequestHandler<GetHierarchyCategoriesQuery, ApiResult<List<CategoryHierarche>>>
{
    public async Task<ApiResult<List<CategoryHierarche>>> Handle(GetHierarchyCategoriesQuery request, CancellationToken cancellationToken)
    {
        var queryable = categoryRepository.GetAllAsync()
            .OrderBy(x => x.Id)
            // .Where(c => 
            //     request.Name != null && request.Code != null  
            //                          && (c.Name.Contains(request.Name) || c.Code.Contains(request.Code)))
            .Take(200);
        
        var categories = await queryable
            .Select(c => new CategoryHierarche
            {
               Id = c.Id,
               Icon = c.Icon,
               Name = c.Name,
               ParentId = c.ParentId,
               SortOrder = c.SortOrder
            }).ToListAsync(cancellationToken);

        var categoryHeHierarche = GetCategoryHeHierarche(categories);

        return ApiSuccessResult<List<CategoryHierarche>>.Instance.WithMessage().WithData(categoryHeHierarche);
    }

    private List<CategoryHierarche> GetCategoryHeHierarche(List<CategoryHierarche> categories, long parentId = 0)
    {
        var parentCategories = categories.Where(x => x.ParentId == parentId)
            .OrderBy(x => x.SortOrder)
            .ToList();
        
        var remainningCategory = categories.Except(parentCategories).ToList();

        if (remainningCategory.Count == 0)
            return [];
        
        //Recursion get children categories
        foreach (var category in parentCategories)
            category.Childs = GetCategoryHeHierarche(remainningCategory, category.Id)
                .OrderBy(x => x.SortOrder)
                .ToList();

        return parentCategories;
    }
}