using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Products.Api.Configurations;
using Products.Api.Models.Data;
using Products.Api.Models.Dto;
using Category = Products.Api.Models.Data.Category;

namespace Products.Api.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Models.Data.Category> _categoriesCollection;
    private readonly IMongoCollection<Models.Data.Product> _productsCollection;
    public CategoryRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
    {
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _categoriesCollection = database.GetCollection<Models.Data.Category>(settings.Value.CategoryCollectionName);
        _productsCollection = database.GetCollection<Models.Data.Product>(settings.Value.ProductCollectionName);
    }

    public async Task<IEnumerable<Models.Dto.Category>> GetAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoriesCollection.Find(_ => true).ToListAsync(cancellationToken);
        return categories.Select(u => new Models.Dto.Category
        {
            Id = u.Id.ToString(),
            Name = u.Name,
        });
    }

    public async Task<IEnumerable<GetProduct>> GetProductsAsync(string categoryId, CancellationToken cancellationToken)
    {
        var categoryObjectId = new ObjectId(categoryId);
        var filter = Builders<Product>.Filter.ElemMatch(p => p.Categories, c => c.Id == categoryObjectId);
        var products = await _productsCollection.Find(filter).ToListAsync(cancellationToken);

        return products.Select(p =>
            new GetProduct
            {
                Categories = p.Categories.Select(c => new Models.Dto.Category
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                }),
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CreatedAt = p.CreatedAt
            });
    }

    public async Task<IEnumerable<Models.Dto.Category>> GetAsync(List<string> categoryIds, CancellationToken cancellationToken)
    {
        var categoryObjectIds = categoryIds.Select(c => ObjectId.Parse(c));

        var categories = await _categoriesCollection.Find(c => categoryObjectIds.Contains(c.Id))
            .ToListAsync(cancellationToken);
        return categories.Select(c => new Models.Dto.Category
        {
            Id = c.Id.ToString(),
            Name = c.Name
        });
    }
}