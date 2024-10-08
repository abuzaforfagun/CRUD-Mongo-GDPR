using Newtonsoft.Json;

namespace User.Api.Dto;

public class GetUserDetails
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("email")] public string Email { get; set; } = string.Empty;

    [JsonProperty("cpr_number")] public string? CPRNumber { get; set; }
}