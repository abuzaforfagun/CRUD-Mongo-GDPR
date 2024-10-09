using Products.Api.Models.Dto;

namespace Products.Api.Services;

public interface IProductRepository
{
    Task CreateAsync(CreateProduct product);
    Task<List<GetProduct>> GetAsync(CancellationToken cancellationToken);
}