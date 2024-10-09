using Products.Api.Models.Dto;

namespace Products.Api.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Models.Dto.Category>> GetAsync(CancellationToken cancellationToken);
    Task<IEnumerable<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken);
    Task<IEnumerable<Models.Dto.Category>> GetAsync(List<string> categoryIds, CancellationToken cancellationToken);
}