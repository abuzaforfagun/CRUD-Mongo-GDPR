using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Products.Api.Models.Data;

public class Category
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
}