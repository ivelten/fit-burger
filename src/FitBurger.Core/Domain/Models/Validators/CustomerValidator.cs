using FluentValidation;

namespace FitBurger.Core.Domain.Models.Validators;

public sealed class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        
    }
}