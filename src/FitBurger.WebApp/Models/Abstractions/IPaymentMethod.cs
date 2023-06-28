using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.WebApp.Models.Abstractions;

public interface IPaymentMethod
{
    PaymentMethod? Method { get; set; }
}