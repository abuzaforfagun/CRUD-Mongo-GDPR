﻿namespace Products.Api.Configurations;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CategoryCollectionName { get; set; } = string.Empty;
    public string ProductCollectionName { get; set; } = string.Empty;

}