using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.WebApp.Validators;

public sealed class PhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string phoneNumber && PhoneNumber.IsValidPhoneNumberString(phoneNumber))
            return null;
        
        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName }!);
    }
}