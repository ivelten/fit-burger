using FitBurger.Core.Domain.Entities;

namespace FitBurger.Core.Domain.ValueObjects;

public class OrderPayment
{
    public OrderPayment(PaymentMethod method, decimal amount)
    {
        Method = method;
        Amount = amount;
    }

    protected OrderPayment()
    {
    }

    public int Id { get; protected set; }
    
    public PaymentMethod Method { get; protected set; }
    
    public decimal Amount { get; protected set; }

    public virtual Order Order { get; protected set; } = default!;
}