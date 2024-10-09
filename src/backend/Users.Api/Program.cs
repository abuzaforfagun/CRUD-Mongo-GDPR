using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using User.Api.Repositories;
using User.Api.Services;
using Users.Api.Configurations;
using Users.Api.Repositories;
using Users.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.Configure<CryptographyConfig>(builder.Configuration.GetSection("Encryption"));


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));
var databaseSettings = builder.Configuration.GetSection("MongoDb").Get<MongoDbSettings>();
var mongoClient = new MongoClient(databaseSettings!.ConnectionString);
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return mongoClient.GetDatabase(settings.DatabaseName);
});


builder.Services.AddScoped<ICryptographyService, CryptographyService>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
