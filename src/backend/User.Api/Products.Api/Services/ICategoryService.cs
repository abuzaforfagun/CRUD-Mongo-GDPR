using Products.Api.Models.Dto;

namespace Products.Api.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAsync(CancellationToken cancellationToken);
    Task<List<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken);
}