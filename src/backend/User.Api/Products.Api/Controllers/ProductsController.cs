using Microsoft.AspNetCore.Mvc;
using Products.Api.Models.Dto;
using Products.Api.Services;

namespace Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesErrorResponseType(typeof(void))]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesErrorResponseType(typeof(BadRequestResult))]
    public async Task<IActionResult> CreateAsync(CreateProduct payload)
    {
        try
        {
            await _productsService.CreateAsync(payload);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Created();
    }

    [ProducesResponseType(typeof(List<GetProduct>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = new List<GetProduct>();

        try
        {
            products = await _productsService.GetProductsAsync(cancellationToken);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(products);
    }
}