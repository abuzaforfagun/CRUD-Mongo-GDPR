using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Products.Api.Configurations;
using Products.Api.Models.Dto;
using Products.Api.Services;

namespace Products.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICategoryService _categoryService;
    private readonly IMongoCollection<Models.Data.Product> _productsCollection;

    public ProductRepository(IMongoClient mongoClient, ICategoryService categoryService, IOptions<MongoDbSettings> settings)
    {
        _categoryService = categoryService;
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _productsCollection = database.GetCollection<Models.Data.Product>(settings.Value.ProductCollectionName);
    }

    public async Task CreateAsync(CreateProduct product, IEnumerable<Category> categories)
    {
        var dbProduct = new Models.Data.Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Categories = categories.Select(c => new Models.Data.Category
            {
                Id = ObjectId.Parse(c.Id),
                Name = c.Name,
            }).ToList(),
            CreatedAt = DateTime.UtcNow
        };

        await _productsCollection.InsertOneAsync(dbProduct);
    }

    public async Task<List<GetProduct>> GetAsync(CancellationToken cancellationToken)
    {
        var products = await _productsCollection.Find(_ => true).ToListAsync(cancellationToken);

        return products.Select(p => new GetProduct
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Categories = p.Categories.Select(c => new Models.Dto.Category
            {
                Id = c.Id.ToString(),
                Name = c.Name,
            }).ToList(),
            CreatedAt = p.CreatedAt
        }).ToList();
    }
}