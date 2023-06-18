using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

public class OrderPayment : Entity
{
    public OrderPayment(PaymentMethod method, decimal amount)
    {
        Method = method;
        Amount = amount;
    }

    protected OrderPayment()
    {
    }

    public PaymentMethod Method { get; protected set; }

    public decimal Amount { get; protected set; }

    public virtual Order Order { get; protected set; } = default!;
}