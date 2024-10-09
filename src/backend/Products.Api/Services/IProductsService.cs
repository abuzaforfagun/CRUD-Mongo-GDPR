using Products.Api.Models.Dto;

namespace Products.Api.Services;

public interface IProductsService
{
    Task CreateAsync(CreateProduct product);
    Task<List<GetProduct>> GetProductsAsync(CancellationToken cancellationToken);
}