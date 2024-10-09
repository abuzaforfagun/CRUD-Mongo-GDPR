using Products.Api.Models.Dto;

namespace Products.Api.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAsync(CancellationToken cancellationToken);
    Task<List<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken);
    Task<bool> IsExist(List<string> categoryIds, CancellationToken cancellationToken);
}
