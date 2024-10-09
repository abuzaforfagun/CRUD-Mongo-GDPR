namespace Users.Api.Models.Dto;

public class GetUsers
{
    public IEnumerable<User> Users { get; set; }
    //TODO: Implement pagination

    public GetUsers()
    {
        Users = new List<User>();
    }
}

public class User
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? CPRNumber { get; set; }

    public DateTime CreatedAt { get; set; }
}