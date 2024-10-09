using Products.Api.Models.Dto;

namespace Products.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetAsync(CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAsync(cancellationToken);
    }

    public async Task<List<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken)
    {
        var isValidCategory = await IsExist(new List<string> {categoryId}, cancellationToken);
        if (!isValidCategory)
        {
            //TODO: Use custom exception
            throw new BadHttpRequestException("Invalid category id(s)");
        }

        return await _categoryRepository.GetProductsAsync(categoryId, cancellationToken);
    }

    public async Task<bool> IsExist(List<string> categoryIds, CancellationToken cancellationToken)
    {
        return await _categoryRepository.IsExist(categoryIds, cancellationToken);
    }
}