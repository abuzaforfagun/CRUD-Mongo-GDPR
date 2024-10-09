using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using User.Api.Extensions;

namespace User.Api.Models.Dto
{
    public class CreateUser
    {
        [Required(ErrorMessage = "Full name is required")]
        [NotNull]
        [JsonProperty("full_name")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [NotNull]
        [JsonProperty("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [NotNull]
        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "CPR Number is required")]
        [NotNull]
        [JsonProperty("cpr_number")]
        public string? CPRNumber { get; set; }

        //TODO: Use a better name please
        public CreateUser GetMaskedData()
        {
            return new CreateUser
            {
                FullName = FullName,
                Email = Email.ToMaskedEmail(),
                CPRNumber = CPRNumber.ToMaskedCPR(),
                Password = Password.ToMaskedPassword(),
                Phone = Phone?.ToMaskedPhoneNumber()
            };
        }
    }
}
