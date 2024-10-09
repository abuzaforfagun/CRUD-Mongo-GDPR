using MongoDB.Bson;

namespace Products.Api.Models.Data;

public class Category
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
}