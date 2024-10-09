using Newtonsoft.Json;

namespace Products.Api.Models.Dto;

public class GetProduct
{
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("description")] public string Description { get; set; } = string.Empty;

    [JsonProperty("price")] public decimal Price { get; set; }

    [JsonProperty("categories")] public List<Category> Categories { get; set; } = new();

    [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
    
}