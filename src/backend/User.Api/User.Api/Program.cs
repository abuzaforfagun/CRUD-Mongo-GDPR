using Microsoft.Extensions.Options;
using MongoDB.Driver;
using User.Api.Configurations;
using User.Api.Repositories;
using User.Api.Services;

var builder = WebApplication.CreateBuilder(args);

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
