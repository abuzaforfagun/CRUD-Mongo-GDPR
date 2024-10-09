using Newtonsoft.Json;

namespace User.Api.Models.Dto;

public class GetUsers
{
    [JsonProperty("users")]
    public IEnumerable<User> Users { get; set; }
    //TODO: Implement pagination

    public GetUsers()
    {
        Users = new List<User>();
    }
}

public class User
{
    [JsonProperty("id")] public string Id { get; set; } = string.Empty;

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("email")] public string Email { get; set; } = string.Empty;

    [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
}