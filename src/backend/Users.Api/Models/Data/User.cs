using MongoDB.Bson;

namespace Users.Api.Models.Data;

public class User
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string CPRNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    public User(string name, string email, string? phoneNumber, string cprNumber, string password)
    {
        Id = ObjectId.GenerateNewId();
        Name = name;
        PhoneNumber = phoneNumber;
        CPRNumber = cprNumber;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }
}