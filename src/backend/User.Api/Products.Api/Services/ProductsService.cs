using Products.Api.Models.Dto;
using Products.Api.Repositories;

namespace Products.Api.Services;

public class ProductsService : IProductsService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryService _categoryService;
    private readonly ILogger<ProductsService> _logger;

    public ProductsService(IProductRepository productRepository, ICategoryService categoryService, ILogger<ProductsService> logger)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
        _logger = logger;
    }

    public async Task CreateAsync(CreateProduct product)
    {
        IEnumerable<Category> categories;
        try
        {
            categories = await _categoryService.GetAsync(product.Categories, CancellationToken.None);
        }
        catch (BadHttpRequestException ex)
        {
            _logger.LogError("Unable to get categories", ex);
            throw;
        }
        var categoriesList = categories.ToList();

        if (categoriesList.Count() != product.Categories.Count)
        {
            //TODO: Use custom exception
            throw new BadHttpRequestException("Invalid category id(s)");
        }

        try
        {
            await _productRepository.CreateAsync(product, categoriesList);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to create product [ProductName={product.Name}][Categories={product.Categories}][Price={product.Price}]");
            throw;
        }
    }

    public async Task<List<GetProduct>> GetProductsAsync(CancellationToken cancellationToken)
    {
        return await _productRepository.GetAsync(cancellationToken);
    }
}

