﻿using Newtonsoft.Json;

namespace Products.Api.Models.Dto;

public class Category
{
    [JsonProperty("id")] public string Id { get; set; } = string.Empty;
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
}