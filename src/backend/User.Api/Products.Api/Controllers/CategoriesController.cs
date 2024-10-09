using Microsoft.AspNetCore.Mvc;
using Products.Api.Models.Dto;
using Products.Api.Services;

namespace Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesErrorResponseType(typeof(void))]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        IEnumerable<Category> products = new List<Category>();

        try
        {
            products = await _categoryService.GetAsync(cancellationToken);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(products);
    }

    [ProducesResponseType(typeof(List<GetProduct>), StatusCodes.Status200OK)]
    [HttpGet("{categoryId}/products")]
    public async Task<IActionResult> GetProductsAsync(string categoryId, CancellationToken cancellationToken)
    {
        IEnumerable<GetProduct> products = new List<GetProduct>();

        try
        {
            products = await _categoryService.GetProductsAsync(categoryId, cancellationToken);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(products);
    }
}