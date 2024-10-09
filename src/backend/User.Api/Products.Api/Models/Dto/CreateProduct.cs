using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Products.Api.Models.Dto;

public class CreateProduct
{
    [JsonProperty("name")] 
    [Required]
    [NotNull]
    public string? Name { get; set; }

    [JsonProperty("description")]
    [Required]
    [NotNull]
    public string? Description { get; set; }

    [JsonProperty("price")]
    [Required]
    public decimal Price { get; set; }

    [JsonProperty("categories")]
    [Required]
    [NotNull]
    public List<string>? Categories { get; set; }
}