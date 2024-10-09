using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Users.Api.Extensions;

namespace Users.Api.Models.Dto;

public class CreateUser
{
    [Required(ErrorMessage = "Full name is required")]
    [NotNull]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [NotNull]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [NotNull]
    public string? Password { get; set; }

    public string? Phone { get; set; }

    [Required(ErrorMessage = "CPR Number is required")]
    [NotNull]
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