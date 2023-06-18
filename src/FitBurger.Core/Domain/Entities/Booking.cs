using FitBurger.Core.Domain.Entities.Abstractions;

namespace FitBurger.Core.Domain.Entities;

public class Booking : Entity
{
    public Booking(
        DateTime bookingDateTime,
        DateTime fromDateTime,
        DateTime toDateTime,
        byte amountOfPeople)
    {
        BookingDateTime = bookingDateTime;
        FromDateTime = fromDateTime;
        ToDateTime = toDateTime;
        AmountOfPeople = amountOfPeople;
    }

    protected Booking()
    {
    }

    public DateTime BookingDateTime { get; protected set; }

    public DateTime FromDateTime { get; protected set; }

    public DateTime ToDateTime { get; protected set; }

    public byte AmountOfPeople { get; protected set; }

    public virtual Customer Customer { get; protected set; } = default!;

    public virtual Attendant? Attendant { get; protected set; }
}