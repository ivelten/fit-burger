namespace FitBurger.Core.Domain.Models;

public class Booking
{
    public Booking(DateTime dateTime, int amountOfPeople, Customer customer)
    {
        DateTime = dateTime;
        AmountOfPeople = amountOfPeople;
        Customer = customer;
    }

    protected Booking()
    {
    }

    public int Id { get; protected set; }
    
    public DateTime DateTime { get; protected set; }
    
    public int AmountOfPeople { get; protected set; }

    public virtual Customer Customer { get; protected set; } = default!;
}