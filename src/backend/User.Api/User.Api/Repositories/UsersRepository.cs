﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using User.Api.Configurations;
using User.Api.Models.Dto;

namespace User.Api.Repositories;

public class UsersRepository : IUserRepository
{
    private readonly IMongoCollection<Models.Data.User> _collection;
    public UsersRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
    {
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Models.Data.User>(settings.Value.CollectionName);
    }

    public async Task CreateAsync(string name, string email, string cprNumber, string? phone, string password)
    {
        var model = new Models.Data.User(name, email, phone, cprNumber);

        await _collection.InsertOneAsync(model);
    }

    public async Task<GetUserDetails> GetAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync(cancellationToken);

        return new GetUserDetails
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            CPRNumber = user.CPRNumber,
            Name = user.Name
        };
    }
        

    public async Task<GetUsers> GetAllAsync(CancellationToken cancellationToken)
    {
        var dbUsers = await _collection.Find(_ => true).ToListAsync(cancellationToken);
        var dtos = dbUsers.Select(u => new Models.Dto.User
        {
            Id = u.Id.ToString(),
            Email = u.Email,
            Name = u.Name,
            CreatedAt = u.CreatedAt
        });

        return new GetUsers
        {
            Users = dtos
        };
    }
}