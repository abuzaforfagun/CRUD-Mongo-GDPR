using Newtonsoft.Json;

namespace User.Api.Dto;

public class GetUsers
{
    [JsonProperty("users")]
    public List<User> Users { get; set; } = new();
    //TODO: Implement pagination

    public GetUsers()
    {
        Users = new();
    }
}

public class User
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("email")] public string Email { get; set; } = string.Empty;
}