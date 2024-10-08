using System.Runtime.ConstrainedExecution;

namespace User.Api.Extensions;

public static class StringExtensions
{
    public static string ToMaskedEmail(this string email)
    {
        if (string.IsNullOrEmpty(email) || !email.Contains("@"))
        {
            return email;
        }

        var emailParts = email.Split('@');
        string localPart = emailParts[0];
        string domainPart = emailParts[1];

        string maskedLocalPart = localPart.Length > 2
            ? localPart.Substring(0, 2) + new string('*', localPart.Length - 2)
            : localPart;

        return $"{maskedLocalPart}@{domainPart}";
    }

    public static string ToMaskedCPR(this string cpr)
    {
        if (string.IsNullOrEmpty(cpr))
        {
            return cpr;
        }

        if (cpr.Length <= 4)
        {
            return new string('*', cpr.Length);
        }
        

        var maskedText = cpr.Substring(0, 2)
                            + new string('*', cpr.Length - 4)
                            + cpr.Substring(cpr.Length - 2);

        return maskedText;
    }

    public static string ToMaskedPassword(this string password)
    {
        return new string('*', password.Length);
    }

    // ToMaskedCPR and ToMaskedPhoneNumber are identical, 
    // But we need to keep those separate because
    // Later on we might need to change some business logic
    public static string ToMaskedPhoneNumber(this string phoneNumber)
    {
        if (phoneNumber.Length <= 4)
        {
            return new string('*', phoneNumber.Length);
        }

        var maskedNumber = new string('*', phoneNumber.Length - 4) + phoneNumber.Substring(phoneNumber.Length - 4);

        return maskedNumber;
    }
}
