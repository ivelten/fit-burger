namespace FitBurger.Core.Domain.Models;

public class Booking
{
    public Booking(
        DateTime bookingDateTime, 
        DateTime fromDateTime,
        DateTime toDateTime,
        int amountOfPeople)
    {
        BookingDateTime = bookingDateTime;
        FromDateTime = fromDateTime;
        ToDateTime = toDateTime;
        AmountOfPeople = amountOfPeople;
    }

    protected Booking()
    {
    }

    public int Id { get; protected set; }
    
    public DateTime BookingDateTime { get; protected set; }
    
    public DateTime FromDateTime { get; protected set; }
    
    public DateTime ToDateTime { get; protected set; }
    
    public int AmountOfPeople { get; protected set; }

    public virtual Customer Customer { get; protected set; } = default!;

    public virtual Attendant? Attendant { get; protected set; }
}