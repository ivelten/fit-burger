using FitBurger.Core.Domain.Entities;

namespace FitBurger.Core.Domain.ValueObjects;

public class OrderPayment : EntityWithId
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