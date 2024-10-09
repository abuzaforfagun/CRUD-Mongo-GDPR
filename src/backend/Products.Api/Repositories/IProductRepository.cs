using Products.Api.Models.Dto;

namespace Products.Api.Repositories;

public interface IProductRepository
{
    Task CreateAsync(CreateProduct product, IEnumerable<Category> categories);
    Task<List<GetProduct>> GetAsync(CancellationToken cancellationToken);
}