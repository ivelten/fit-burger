namespace FitBurger.Core.Domain.Models;

public class Booking
{
    public Booking(DateTime dateTime, int amountOfPeople, Customer customer, Attendant? attendant = null)
    {
        DateTime = dateTime;
        AmountOfPeople = amountOfPeople;
        Customer = customer;
        Attendant = attendant;
    }

    protected Booking()
    {
    }

    public int Id { get; protected set; }
    
    public DateTime DateTime { get; protected set; }
    
    public int AmountOfPeople { get; protected set; }

    public virtual Customer Customer { get; protected set; } = default!;

    public virtual Attendant? Attendant { get; protected set; }
}