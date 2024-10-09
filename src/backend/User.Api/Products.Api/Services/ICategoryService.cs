using Products.Api.Models.Dto;

namespace Products.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAsync(CancellationToken cancellationToken);
    
    Task<IEnumerable<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken);

    Task<IEnumerable<Category>> GetAsync(List<string> categoryIds, CancellationToken cancellationToken);
}