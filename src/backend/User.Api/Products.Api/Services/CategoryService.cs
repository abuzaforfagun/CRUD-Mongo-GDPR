using Products.Api.Models.Dto;
using Products.Api.Repositories;

namespace Products.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAsync(CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAsync(cancellationToken);
    }

    public async Task<IEnumerable<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken)
    {
        var category = await GetAsync(new List<string> {categoryId}, cancellationToken);
        if (!category.Any())
        {
            //TODO: Use custom exception
            throw new BadHttpRequestException("Invalid category id(s)");
        }

        return await _categoryRepository.GetProductsAsync(categoryId, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAsync(List<string> categoryIds, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAsync(categoryIds, cancellationToken);
    }
}