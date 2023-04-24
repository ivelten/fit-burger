using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.WebApp.Validators;

public class CpfAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string cpf && Cpf.IsValidCpfString(cpf))
            return null;
        
        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName }!);
    }
}