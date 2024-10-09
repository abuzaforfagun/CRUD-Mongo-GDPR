using Products.Api.Models.Dto;

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
        var isValidCategory = await _categoryService.IsExist(product.Categories, CancellationToken.None);

        if (!isValidCategory)
        {
            //TODO: Use custom exception
            throw new BadHttpRequestException("Invalid category id(s)");
        }

        try
        {
            await _productRepository.CreateAsync(product);
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

