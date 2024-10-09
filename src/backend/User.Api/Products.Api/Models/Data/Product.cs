namespace Products.Api.Models.Data;

public class Product
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public List<Category> Categories { get; set; } = new();

    public DateTime CreatedAt { get; set; }
}