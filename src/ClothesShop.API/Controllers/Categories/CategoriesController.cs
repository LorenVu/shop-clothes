using Clothes.Application.Features.Queries.Categories.GetCategoriesPagination;
using Clothes.Application.Features.Queries.Categories.GetCategoryById;
using Clothes.Application.Features.Queries.Categories.GetHierarchyCategories;
using Clothes.Infrastructure.Shared.Responses;
using ClothesShop.API.Controllers.Configs;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClothesShop.API.Controllers.Categories;

[Route("/api/v1/[controller]")]
public class CategoriesController(IMediator mediator) : BaseController
{
    [HttpPost("pagination")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Get categories")]
    public async Task<IActionResult> GetCategoriesPagination([FromBody] GetCategoriesPaginationQuery query, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)    
            return BadRequest();
        
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("{id:long}")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Get category by id")]
    public async Task<IActionResult> GetCategoryById([FromRoute] long id, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)    
            return BadRequest();
        
        var query = new GetCategoryById(id);
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("hierarchy")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Get hierarchy categories")]
    public async Task<IActionResult> GetHierarchyCategory([FromQuery] GetHierarchyCategoriesQuery query, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)    
            return BadRequest();
        
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}