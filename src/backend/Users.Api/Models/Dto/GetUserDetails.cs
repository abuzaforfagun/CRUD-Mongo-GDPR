using Newtonsoft.Json;

namespace User.Api.Models.Dto;

public class GetUserDetails
{
    [JsonProperty("id")] public string Id { get; set; } = string.Empty;

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("email")] public string Email { get; set; } = string.Empty;

    [JsonProperty("cpr_number")] public string? CPRNumber { get; set; }
}