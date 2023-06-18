using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.WebApp.Validators;

public class EmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email && Email.IsValidEmailString(email))
            return null;

        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName }!);
    }
}