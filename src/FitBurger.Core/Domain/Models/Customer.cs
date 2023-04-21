namespace FitBurger.Core.Domain.Models;

public class Customer
{
    public Customer(string name, string phoneNumber, string email, string address, Cpf cpf)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Cpf = cpf;
        Bookings = new List<Booking>();
    }

    protected Customer()
    {
    }
    
    public int Id { get; protected set; }

    public string Name { get; protected set; } = default!;
    
    public string PhoneNumber { get; protected set; } = default!;
    
    public string Email { get; protected set; } = default!;
    
    public string Address { get; protected set; } = default!;
    
    public Cpf Cpf { get; protected  set; } = default!;
    
    public virtual ICollection<Booking> Bookings { get; protected set; } = default!;
}